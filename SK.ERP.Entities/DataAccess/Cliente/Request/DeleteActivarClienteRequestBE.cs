using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Cliente.Request
{
    public class DeleteActivarClienteRequestBE
    {
        public List<string> IdCliente { get; set; }
        public int Estado { get; set; }
    }
}
