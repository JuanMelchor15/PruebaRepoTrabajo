using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Entities;
using SK.ERP.Entities.DataAccess.Registro.Request;
using SK.ERP.Entities.DataAccess.Registro.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class RegistroBL : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public bool SaveRegistro(SaveRegistroRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.RegistroDA())
            {
                return DA.SaveRegistro(RequestBE);
            }

        }
        public ValidarRegistro ValidarRegistro(string Usuario)
        {
            using (var DA = new SK.ERP.DataAccess.RegistroDA())
            {
                return DA.ValidarRegistro(Usuario);
            }
        }
    }
}
