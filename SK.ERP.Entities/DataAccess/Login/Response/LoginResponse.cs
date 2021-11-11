using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Login.Response
{
    public class LoginResponse
    {
        public string Usuario { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Code { get; set; }
    }
}
