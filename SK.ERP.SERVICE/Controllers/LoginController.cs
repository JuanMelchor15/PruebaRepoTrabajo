using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SK.ER.Utilities.General;
using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.Entities.DataAccess.Login.Request;
using SK.ERP.Entities.DataAccess.Login.Response;
using SK.ERP.SERVICE.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;
        public LoginController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IMapper mapper)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<LoginController>();
            _mapper = mapper;

            string varTokenLifetime = Configuration["Jwt:TokenLifetime"];
            int[] LifeTimeParts = varTokenLifetime.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            TimeSpan TokenLifetime = new TimeSpan(LifeTimeParts[0], LifeTimeParts[1], LifeTimeParts[2]);

            GeneralModel.ConnectionString = Configuration["ConnectionStrings:SK"];


            _jwtOptions = new JwtOptions
            {
                AsymmetricKeyPrivate = Configuration["Jwt:Asymmetric:PrivateKey"],
                TokenLifetime = TokenLifetime
            };
        }
        [ApiKeyAuth]
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest ResquestBE)
        {
            var genericresponse = new GenericResponseObject();

            using (var LoginBL = new SK.ERP.Business.DataAccess.LoginBL(_jwtOptions))
            {
                var data = LoginBL.Login(ResquestBE);
                var response = new LoginResponse();
                genericresponse.Code = Enums.eCode.OK;
                genericresponse.Data = data;
            }

            return Ok(genericresponse);
        }
    }
}
