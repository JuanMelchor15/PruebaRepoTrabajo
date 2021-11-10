using SK.ERP.Entities.DataAccess.Persona.Request;
using SK.ERP.Entities.DataAccess.Persona.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class PersonaBL : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<ListaPersona> GetPersona()
        {
            using (var DA = new SK.ERP.DataAccess.PersonaDA())
            {
                return DA.GetPersona();
            }
        }
        public bool SavePersona(SavePersonaRequest RequestBE)
        {
            using (var DA = new SK.ERP.DataAccess.PersonaDA())
            {
                return DA.SavePersona(RequestBE);
            }
        }
    }
}
