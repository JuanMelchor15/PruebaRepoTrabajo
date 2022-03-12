using SK.ER.Utilities.Keys;
using SK.ER.Utilities.Methods;
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
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        public string CFechaFin
        {
            get
            {
                return string.Format(Constants.FORMAT_DATE, FechaFin);
            }
        }
        public string CFechaInicio
        {
            get
            {
                return string.Format(Constants.FORMAT_DATE, FechaInicio);
            }
        }
        public string CDiasRestantes
        {
            get
            {
                var FechaActual = GeneralMethods.FechaActualLimaQuito();
                var DateFechaActual = string.Format(Constants.FORMAT_DATE, FechaActual);
                var Restante = GeneralMethods.DiasRestantes(Convert.ToDateTime(DateFechaActual), FechaFin);

                if (Restante.Days==0)
                {
                    return "Hoy Finaliza Menbresia";
                }
                else if ( Restante.Days <0)
                {
                    return "0";
                }
                return Convert.ToString(Restante.Days);
            }
        }
        public string CEstado
        {
            get
            {
                if (Estado == 1)
                {
                    return "Activo";
                }
                //else if (CDiasRestantes == "Hoy Finaliza Menbresia")
                //{
                //    return "Activo";
                //}
                else
                {
                    return "Inactivo";
                }

            }
        }
    }
}
