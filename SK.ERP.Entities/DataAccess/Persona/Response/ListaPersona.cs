using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Persona.Response
{
    public class ListaPersona
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPart { get; set; }
        public string ApellidoMat { get; set; }
        public string telefono { get; set; }
        public bool bEstado { get; set; }
   
    }
}
