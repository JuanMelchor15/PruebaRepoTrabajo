using SK.ERP.Entities.DataAccess.Cliente.Request;
using SK.ERP.Entities.DataAccess.Cliente.Response;
using SK.ERP.Entities.DataAccess.Persona.Request;
using SK.ERP.Entities.DataAccess.Persona.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class ClienteBL : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ListaCLienteId GetListaClienteId(int IdCliente)
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
                return DA.BuscarCliente(Codigo, Estado);
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
                return DA.UpdateCliente(RequestBE);
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
