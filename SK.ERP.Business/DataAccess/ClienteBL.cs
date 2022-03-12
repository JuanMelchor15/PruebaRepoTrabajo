using SK.ER.Utilities.Keys;
using SK.ER.Utilities.Methods;
using SK.ERP.Entities.DataAccess.Cliente.Request;
using SK.ERP.Entities.DataAccess.Persona.Request;
using SK.ERP.Entities.DataAccess.Persona.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class ClienteBL : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ListaCliente GetListaClienteId(int IdCliente)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.GetListaClienteId(IdCliente);
            }
        }
        public List<ListaCliente> BuscarCliente(string Codigo, int Estado)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                var Respuesta = DA.BuscarCliente(Codigo, Estado);
                foreach (var Clientes in Respuesta)
                {
                    var FechaActual = GeneralMethods.FechaActualLimaQuito();
                    var FechaCreacionDate = string.Format(Constants.FORMAT_DATE, FechaActual);
                    FechaActual = DateTime.ParseExact(FechaCreacionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (Clientes.FechaFin == FechaActual)
                        DA.DesactivarCliente(Clientes.FechaFin);
                }
                return Respuesta;

            }
        }
        public bool SaveCliente(SaveClienteRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.SaveCliente(RequestBE);
            }
        }
        public bool UpdateCliente(UpdateClienteRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                var Respuesta = DA.UpdateCliente(RequestBE);

                if (Respuesta)
                {
                    DA.ActivarCliente(RequestBE.FechaInicio, RequestBE.IdCliente);
                }

                return Respuesta;
            }
        }
        public bool DeleteActivarCliente(DeleteActivarClienteRequestBE RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.DeleteActivarCliente(RequestBE);
            }
        }
    }
}
