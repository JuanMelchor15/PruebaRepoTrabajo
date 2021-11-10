using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Persona.Request
{
    public class SavePersonaRequest
    {
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMar { get; set; }
        public string Telefono { get; set; }

    }
}
