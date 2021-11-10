using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Entities
{
    public class SecurityModel
    {
        public string Url { get; set; }
        public bool SSL { get; set; }
        public int NRO_MAX_INTENTOS { get; set; }
        public int IdAplicacion { get; set; }
    }
}
