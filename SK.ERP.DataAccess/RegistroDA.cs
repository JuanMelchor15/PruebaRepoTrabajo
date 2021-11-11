using SK.ER.Utilities.General;
using SK.ERP.Entities.DataAccess.Registro.Request;
using SK.ERP.Entities.DataAccess.Registro.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SK.ERP.DataAccess
{
    public class RegistroDA : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool SaveRegistro(SaveRegistroRequest RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var Paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@Usuario",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Usuario},
                        new SqlParameter{ParameterName="@Contraseña",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Contraseña},
                        new SqlParameter{ParameterName="@Telefono",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Telefono},
                        new SqlParameter{ParameterName="@Correo",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Correo},
                        new SqlParameter{ParameterName="@FechaHoraRegistro",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.FechaHoraRegistro},
                    };
                    Ado.ExecNonQueryProc("usp_SaveRegistro", Paramaters);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ValidarRegistro ValidarRegistro(string Usuario)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    ValidarRegistro Entity = null;
                    var Paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@Usuario",SqlDbType=SqlDbType.VarChar,SqlValue=Usuario},

                    };
                    var Dr = Ado.ExecDataReaderProc("usp_ValidarUsuarioReg", Paramaters);
                    {
                        if (!Dr.HasRows) { return Entity; }
                        while (Dr.Read())
                        {
                            Entity = new ValidarRegistro();
                            if (Dr["CantidadUsu"] != DBNull.Value) { Entity.CantidadUsu = (int)Dr["CantidadUsu"]; }
                            break;
                        }
                        return Entity;
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
