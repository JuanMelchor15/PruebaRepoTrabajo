using SK.ERP.Entities.DataAccess.Cliente.Request;
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
        public bool DeleteCliente(DeleteClienteRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.DeleteCliente(RequestBE);
            }
        }
        public bool ActivateCliente(DeleteClienteRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.ActivateCliente(RequestBE);
            }
        }
    }
}
