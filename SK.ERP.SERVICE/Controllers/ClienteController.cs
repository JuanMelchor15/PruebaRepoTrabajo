using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SK.ER.Utilities.General;
using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Cliente.Request;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.Entities.DataAccess.Persona.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IMapper _mapper;
        public ClienteController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IMapper mapper)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<ClienteController>();
            GeneralModel.ConnectionString = Configuration["ConnectionStrings:SK"];
            _mapper = mapper;
        }
        [HttpGet]
        [Route("BuscarCliente/{Estado}/{Codigo?}")]
        public IActionResult BuscarCliente(int Estado, string Codigo= "")
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.ClienteBL())
            {
                var data = BL.BuscarCliente(Codigo,Estado);
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
        [HttpPost]
        [Route("SaveCliente")]
        public IActionResult SaveCliente(SaveClienteRequest ResquestBE)
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.ClienteBL())
            {
                var data = BL.SaveCliente(ResquestBE);
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
        [HttpPost]
        [Route("UpdateCliente")]
        public IActionResult UpdateCliente(UpdateClienteRequest ResquestBE)
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.ClienteBL())
            {
                var data = BL.UpdateCliente(ResquestBE);
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
        [HttpPost]
        [Route("DeleteCliente")]
        public IActionResult DeleteCliente(DeleteClienteRequest ResquestBE)
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.ClienteBL())
            {
                var data = BL.DeleteCliente(ResquestBE);
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
        [HttpPost]
        [Route("ActivateCliente")]
        public IActionResult ActivateCliente(DeleteClienteRequest ResquestBE)
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.ClienteBL())
            {
                var data = BL.ActivateCliente(ResquestBE);
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
    }
}
