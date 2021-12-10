using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SK.ER.Utilities.Keys;
using SK.ER.Utilities.Methods;
using SK.ERP.DataAccess;
using SK.ERP.Entities.DataAccess.Authentication;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.Entities.DataAccess.Login.Request;
using SK.ERP.Entities.DataAccess.Login.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class LoginBL : IDisposable
    {
        private readonly JwtOptions _jwtOptions;
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public LoginBL(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public AuthenticationResult Login(LoginRequest RequestBE)
        {
            using (var LoginDA = new LoginDA())
            {
                var LoginResponse = LoginDA.Login(RequestBE);
                if (LoginResponse != null)
                {
                    try
                    {
                        IdentityOptions _options = new IdentityOptions();

                        var tokenHandler = new JwtSecurityTokenHandler();
                        RSA rsa = RSA.Create();
                        rsa.ImportRSAPrivateKey( // Convert the loaded key from base64 to bytes.
                            source: Convert.FromBase64String(_jwtOptions.AsymmetricKeyPrivate), // Use the private key to sign tokens
                            bytesRead: out int _); // Discard the out variable 

                        var signingCredentials = new SigningCredentials(
                            key: new RsaSecurityKey(rsa),
                            algorithm: SecurityAlgorithms.RsaSha256Signature // Important to use RSA version of the SHA algo 
                        );

                        //var ListRoles = UserBE.RolesApi;
                        var claimsUser = new List<Claim>
                                {
                                    //new Claim(type:JwtRegisteredClaimNames.UniqueName,value: string.IsNullOrEmpty(LoginResponse.Correo) ? "Generic User" : LoginResponse.Correo),
                                    //new Claim(type:_options.ClaimsIdentity.UserIdClaimType,value:LoginResponse.Code),
                                    //new Claim(type: Constants.Claim_dataBussinessType, value: LoginResponse.BussinessType.ToString()),
                                    //new Claim(type: Constants.Claim_tokenBAZ, value: tokenBAZ),
                                    //new Claim(type: Constants.Claim_userCode, value: LoginResponse.Code),
                                    new Claim(type: Constants.Claim_userName, value: LoginResponse.NombreEmpleado),
                                    new Claim(type:JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString())
                                };

                        bool exito = false;

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claimsUser),
                            Expires = DateTime.UtcNow.Add(_jwtOptions.TokenLifetime),
                            SigningCredentials = signingCredentials
                        };

                        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                        var FechaActualLima = GeneralMethods.FechaActualLimaQuito();
                        var refreshToken = new RefreshTokenBE
                        {
                            JwtId = token.Id,
                            CreationDate = FechaActualLima,
                            ExpiryDate = FechaActualLima.AddMonths(6),
                            Token = Guid.NewGuid().ToString()
                        };
                        exito = true;

                        return new AuthenticationResult
                        {
                            Success = exito,
                            Token = tokenHandler.WriteToken(token),
                            RefreshToken = refreshToken.Token
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { "Usuario o Contraseña Son Incorrectos" }
                    };
                }
            }
        }
    }
}
