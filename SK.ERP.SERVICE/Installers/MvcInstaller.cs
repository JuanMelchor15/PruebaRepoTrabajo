using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SK.ERP.Business.DataAccess;
using SK.ERP.Business.DataAccess.Interfaces;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.SERVICE.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Installers
{
    public class MvcInstaller : IInstaller
    {
        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc(
                options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                    //options.Filters.Add(new CustomAuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //options.JsonSerializerOptions.PropertyNamingPolicy = new NewtonsoftJsonNamingPolicy(new SnakeCaseNamingStrategy());
                })
                .AddFluentValidation(c =>
                {
                    c.RegisterValidatorsFromAssemblyContaining<Startup>();
                    // Optionally set validator factory if you have problems with scope resolve inside validators.
                    c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                })/*
                .AddMvcOptions(options => {
                    options.ModelMetadataDetailsProviders.Clear();
                    options.ModelValidatorProviders.Clear();
                })*/;

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                      .WithMethods("GET", "POST")
                                      .AllowAnyHeader();
                                  });
            });


            var jwtOptions = new JwtOptions();
            Configuration.Bind(key: nameof(jwtOptions), jwtOptions);
            services.AddSingleton(jwtOptions);

            var securityModel = new SecurityModel();
            Configuration.Bind(key: nameof(securityModel), securityModel);
            services.AddSingleton(securityModel);

            var emailOptions = new EmailOptions();
            Configuration.Bind(key: nameof(emailOptions), emailOptions);
            services.AddSingleton(emailOptions);

            services.AddSingleton(provider => {
                // It's required to register the RSA key with depedency injection.
                // If you don't do this, the RSA instance will be prematurely disposed.

                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(Configuration["Jwt:Asymmetric:PublicKey"]),
                    bytesRead: out int _
                );

                return new RsaSecurityKey(rsa);
            });


            SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = rsa,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            //IdentityModelEventSource.ShowPII = true;
            services.AddSingleton(tokenValidationParameters);
            services.AddScoped<IEmailSender, EmailSender>();

            var events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        // How to know if the token was expired?
                        return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = "Unauthorized",
                            Msg = "token expired"
                        }));
                    }
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    var accessToken = context.SecurityToken as JwtSecurityToken;
                    if (accessToken != null)
                    {
                        if (context.Principal.Identity is ClaimsIdentity identity)
                        {
                            identity.AddClaim(new Claim("access_token", accessToken.RawData));
                        }
                    }

                    return Task.CompletedTask;
                }
            };


            services.AddAuthentication(configureOptions: x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true; // <- great for debugging
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = events;

            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                /*options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    return new JsonResult(errors);
                };*/
            });
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }
    }
}
