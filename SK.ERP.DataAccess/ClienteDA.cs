﻿using SK.ER.Utilities.General;
using SK.ERP.Entities.DataAccess.Cliente.Request;
using SK.ERP.Entities.DataAccess.Persona.Request;
using SK.ERP.Entities.DataAccess.Persona.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SK.ERP.DataAccess
{
    public class ClienteDA : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ListaCliente GetListaClienteId(int IdCliente)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    ListaCliente Entity = null;
                    var Paramaters = new SqlParameter[]
                    {
                       new SqlParameter{ParameterName="@IdCliente",SqlDbType=SqlDbType.VarChar,SqlValue=IdCliente },

                    };
                    var Dr = Ado.ExecDataReaderProc("usp_GetClienteId", Paramaters);
                    {
                        if (!Dr.HasRows) { return Entity; }
                        while (Dr.Read())
                        {
                            Entity = new ListaCliente();

                            if (Dr["IdCliente"] != DBNull.Value) { Entity.IdCliente = (int)Dr["IdCliente"]; }
                            if (Dr["Nombres"] != DBNull.Value) { Entity.Nombres = (string)Dr["Nombres"]; }
                            if (Dr["Apellidos"] != DBNull.Value) { Entity.Apellidos = (string)Dr["Apellidos"]; }
                            if (Dr["Dni"] != DBNull.Value) { Entity.Dni = (string)Dr["Dni"]; }
                            if (Dr["Telefono"] != DBNull.Value) { Entity.Telefono = (string)Dr["Telefono"]; }
                            if (Dr["TelefonoRef"] != DBNull.Value) { Entity.TelefonoRef = (string)Dr["TelefonoRef"]; }
                            if (Dr["FechaInicio"] != DBNull.Value) { Entity.FechaInicio = (DateTime)Dr["FechaInicio"]; }
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Estado"] != DBNull.Value) { Entity.Estado = (int)Dr["Estado"]; }

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
        public List<ListaCliente> BuscarCliente(string Dni, int Estado)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaCliente> List = new List<ListaCliente>();
                    var Paramaters = new SqlParameter[]
                    {
                       new SqlParameter{ParameterName="@Dni",SqlDbType=SqlDbType.VarChar,SqlValue=Dni},
                       new SqlParameter{ParameterName="@Estado",SqlDbType=SqlDbType.VarChar,SqlValue=Estado},
                    };
                    var Dr = Ado.ExecDataReaderProc("usp_GetBuscarCliente", Paramaters);
                    {
                        if (!Dr.HasRows) { return List; }
                        while (Dr.Read())
                        {
                            var Entity = new ListaCliente();
                            if (Dr["IdCliente"] != DBNull.Value) { Entity.IdCliente = (int)Dr["IdCliente"]; }
                            if (Dr["Nombres"] != DBNull.Value) { Entity.Nombres = (string)Dr["Nombres"]; }
                            if (Dr["Apellidos"] != DBNull.Value) { Entity.Apellidos = (string)Dr["Apellidos"]; }
                            if (Dr["Dni"] != DBNull.Value) { Entity.Dni = (string)Dr["Dni"]; }
                            if (Dr["Telefono"] != DBNull.Value) { Entity.Telefono = (string)Dr["Telefono"]; }
                            if (Dr["TelefonoRef"] != DBNull.Value) { Entity.TelefonoRef = (string)Dr["TelefonoRef"]; }
                            if (Dr["FechaInicio"] != DBNull.Value) { Entity.FechaInicio = (DateTime)Dr["FechaInicio"]; }
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Estado"] != DBNull.Value) { Entity.Estado = (int)Dr["Estado"]; }
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
        public bool SaveCliente(SaveClienteRequest RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@Nombres",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Nombres},
                        new SqlParameter{ParameterName="@Apellidos",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Apellidos},
                        new SqlParameter{ParameterName="@Dni",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Dni},
                        new SqlParameter{ParameterName="@Telefono",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Telefono},
                        new SqlParameter{ParameterName="@TelefonoRef",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.TelefonoRef},
                        new SqlParameter{ParameterName="@FechaInicio",SqlDbType=SqlDbType.Date,SqlValue=RequestBE.FechaInicio},
                        new SqlParameter{ParameterName="@FechaFin",SqlDbType=SqlDbType.Date,SqlValue=RequestBE.FechaFin},
                    };
                    var Dr = Ado.ExecNonQueryProc("usp_SaveCliente", paramaters);
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        public bool UpdateCliente(UpdateClienteRequest RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@IdCliente",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.IdCliente},
                        new SqlParameter{ParameterName="@Nombres",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Nombres},
                        new SqlParameter{ParameterName="@Apellidos",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Apellidos},
                        new SqlParameter{ParameterName="@Dni",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Dni},
                        new SqlParameter{ParameterName="@Telefono",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Telefono},
                        new SqlParameter{ParameterName="@TelefonoRef",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.TelefonoRef},
                        new SqlParameter{ParameterName="@FechaFin",SqlDbType=SqlDbType.Date,SqlValue=RequestBE.FechaFin},
                        new SqlParameter{ParameterName="@FechaInicio",SqlDbType=SqlDbType.Date,SqlValue=RequestBE.FechaInicio},
                    };
                    var Dr = Ado.ExecNonQueryProc("usp_UpdateCliente", paramaters);
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        public bool DesactivarCliente(DateTime FechaFin)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var Paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@FechaFin", SqlDbType=SqlDbType.Date,SqlValue=FechaFin},
                    };

                    Ado.ExecNonQueryProc("usp_DesctivarCliente", Paramaters);
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        public bool ActivarCliente(DateTime FechaFin,int IdCliente)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var Paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@FechaInicio", SqlDbType=SqlDbType.Date,SqlValue=FechaFin},
                        new SqlParameter{ParameterName="@IdCliente", SqlDbType=SqlDbType.Int,SqlValue=IdCliente},
                    };

                    Ado.ExecNonQueryProc("usp_ActivarCliente", Paramaters);
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        public bool DeleteActivarCliente(DeleteActivarClienteRequestBE RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {

                    foreach (var item in RequestBE.IdCliente)
                    {
                        var paramaters = new SqlParameter[]
                        {
                        new SqlParameter{ParameterName="@IdCliente",SqlDbType=SqlDbType.VarChar,SqlValue=item},
                        new SqlParameter{ParameterName="@Estado",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Estado},

                        };

                        var Dr = Ado.ExecNonQueryProc("usp_DeleteActivarCliente", paramaters);

                    }
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

    }
}
