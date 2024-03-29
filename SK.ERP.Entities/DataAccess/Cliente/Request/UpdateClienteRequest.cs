﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Cliente.Request
{
    public class UpdateClienteRequest
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string TelefonoRef { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }


    }
}
