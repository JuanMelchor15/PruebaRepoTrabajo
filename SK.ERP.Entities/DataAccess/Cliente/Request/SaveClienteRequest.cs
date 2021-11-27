using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Persona.Request
{
    public class SaveClienteRequest
    {
        public string Nombres { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string TelefonoRef { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
