using SK.ER.Utilities.General;
using SK.ERP.Entities.DataAccess.Persona.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.DataAccess
{
    public class PersonaDA : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ListaPersona> GetPersona()
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaPersona> List = new List<ListaPersona>();
                    var Dr = Ado.ExecDataReaderProc("usp_listarPersona", null);
                    {
                        if (!Dr.HasRows) { return List; }
                        while (Dr.Read())
                        {
                            var Entity = new ListaPersona();
                            if (Dr["id"] != DBNull.Value) { Entity.id = (int)Dr["id"]; }
                            if (Dr["Nombre"] != DBNull.Value) { Entity.Nombre = (string)Dr["Nombre"]; }
                            if (Dr["ApellidoPart"] != DBNull.Value) { Entity.ApellidoPart = (string)Dr["ApellidoPart"]; }
                            if (Dr["ApellidoMat"] != DBNull.Value) { Entity.ApellidoMat = (string)Dr["ApellidoMat"]; }
                            if (Dr["telefono"] != DBNull.Value) { Entity.telefono = (string)Dr["telefono"]; }
                            if (Dr["bEstado"] != DBNull.Value) { Entity.bEstado = (bool)Dr["bEstado"]; }
                            List.Add(Entity);
                        }
                        return List;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
