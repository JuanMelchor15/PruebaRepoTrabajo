using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Registro.Request
{
    public class SaveRegistroRequest
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
    }
}
