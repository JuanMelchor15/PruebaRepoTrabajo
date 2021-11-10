using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SK.ERP.Entities.DataAccess.Options;
using SK.ERP.SERVICE.Extensions;
using SK.ERP.SERVICE.Installers;

namespace SK.ERP.SERVICE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider sp)
        {
            SwaggerOptions swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(c =>
            {
                var schemes = env.IsDevelopment() ? new[] { "http" } : new[] { "https" };
                //c.DocumentFilter<TestFilter>();
                /*c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });*/
                c.RouteTemplate = c.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description); });

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseCors("_myAllowSpecificOrigins");

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddSerilog();
            var LogPath = string.Empty;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) LogPath = env.WebRootPath + "\\logs\\log-{Date}.log";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) LogPath = env.WebRootPath + "/logs/log-{Date}.log";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.RollingFile(LogPath)
                .CreateLogger();
        }
    }
}
