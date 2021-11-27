using SK.ER.Utilities.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Persona.Response
{
    public class ListaCliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string TelefonoRef { get; set; }
        public DateTime FechaFin { get; set; }
        public string Codigo { get; set; }

        public string CFechaFin
        {
            get
            {
                return string.Format(Constants.FORMAT_DATE, FechaFin);
            }
        }

    }
}
