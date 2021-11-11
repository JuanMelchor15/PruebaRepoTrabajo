using SK.ER.Utilities.General;
using SK.ERP.Entities.DataAccess.Login.Request;
using SK.ERP.Entities.DataAccess.Login.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SK.ERP.DataAccess
{
    public class LoginDA : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public LoginResponse Login(LoginRequest RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    LoginResponse Entity = null;
                    var Paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@Usuario",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Usuario},
                        new SqlParameter{ParameterName="@Contraseña",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Contraseña},
                    };
                    var Dr = Ado.ExecDataReaderProc("usp_Login", Paramaters);
                    {
                        if (!Dr.HasRows) { return null; }
                        while (Dr.Read())
                        {
                            Entity = new LoginResponse();
                            if (Dr["Usuario"] != DBNull.Value) { Entity.Usuario = (string)Dr["Usuario"]; }
                            if (Dr["Telefono"] != DBNull.Value) { Entity.Telefono = (string)Dr["Telefono"]; }
                            if (Dr["Correo"] != DBNull.Value) { Entity.Correo = (string)Dr["Correo"]; }
                            if (Dr["Code"] != DBNull.Value) { Entity.Code = Convert.ToString(Dr["Code"]); }
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
