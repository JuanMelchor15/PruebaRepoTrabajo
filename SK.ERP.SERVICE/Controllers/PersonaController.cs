using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SK.ER.Utilities.General;
using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IMapper _mapper;
        public PersonaController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IMapper mapper)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<PersonaController>();
            GeneralModel.ConnectionString = Configuration["ConnectionStrings:SK"];
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetPersana")]
        public IActionResult GetPersana()
        {
            var GenericResponse = new GenericResponseObject();
            using (var BL = new SK.ERP.Business.DataAccess.PersonaBL())
            {
                var data = BL.GetPersona();
                GenericResponse.Code = Enums.eCode.OK;
                GenericResponse.Data = data;
            }
            return Ok(GenericResponse);
        }
    }
}
