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
        public List<ListaCliente> GetCliente()
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.GetCliente();
            }
        }
        public List<ListaCliente> GetClienteDesac()
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.GetClienteDesac();
            }
        }
        public List<ListaCliente> BuscarCliente(string Codigo)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.BuscarCliente(Codigo);
            }
        }
        public List<ListaCliente> BuscarClienteDesc(string Codigo)
        {
            using (var DA = new SK.ERP.DataAccess.ClienteDA())
            {
                return DA.BuscarClienteDesc(Codigo);
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
