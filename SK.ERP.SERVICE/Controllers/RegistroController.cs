using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SK.ER.Utilities.General;
using SK.ER.Utilities.Keys;
using SK.ER.Utilities.Methods;
using SK.ERP.Entities.DataAccess.Dto;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.Entities.DataAccess.Registro.Request;
using SK.ERP.SERVICE.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IMapper _mapper;

        public RegistroController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IMapper mapper)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<ClienteController>();
            GeneralModel.ConnectionString = Configuration["ConnectionStrings:SK"];
            _mapper = mapper;
        }
        [ApiKeyAuth]
        [HttpPost]
        [Route("SaveRegistro")]
        public IActionResult SaveRegistro([FromBody] DtoSaveRegistroRequest dtoSaveRegistroRequest)
        {
            var GenerciResponse = new GenericResponseObject();
            var RequestBE = _mapper.Map<SaveRegistroRequest>(dtoSaveRegistroRequest);
            var FechaActual = GeneralMethods.FechaActualLimaQuito();
            RequestBE.FechaHoraRegistro = FechaActual;
            using (var BL = new SK.ERP.Business.DataAccess.RegistroBL())
            {
                var ValidarUsua = BL.ValidarRegistro(RequestBE.Usuario);
                if (ValidarUsua.CantidadUsu > 0)
                {
                    GenerciResponse.Code = Enums.eCode.VAL;
                    GenerciResponse.Message = "El Usuario " + RequestBE.Usuario + " Ya Existe";
                    return Ok(GenerciResponse);
                }
                var data = BL.SaveRegistro(RequestBE);
                GenerciResponse.Code = Enums.eCode.OK;
                GenerciResponse.Data = data;
            }
            return Ok(GenerciResponse);
        }

    }
}
