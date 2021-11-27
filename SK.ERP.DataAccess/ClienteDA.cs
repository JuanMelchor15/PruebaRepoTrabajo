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

        public List<ListaCliente> GetCliente()
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaCliente> List = new List<ListaCliente>();
                    var Dr = Ado.ExecDataReaderProc("usp_GetCliente", null);
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
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Codigo"] != DBNull.Value) { Entity.Codigo = (string)Dr["Codigo"]; }
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
        public List<ListaCliente> GetClienteDesac()
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaCliente> List = new List<ListaCliente>();
                    var Dr = Ado.ExecDataReaderProc("usp_GetClienteDesc", null);
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
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Codigo"] != DBNull.Value) { Entity.Codigo = (string)Dr["Codigo"]; }
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
        public List<ListaCliente> BuscarCliente(string Codigo)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaCliente> List = new List<ListaCliente>();
                    var Paramaters = new SqlParameter[]
                    {
                       new SqlParameter{ParameterName="@Codigo",SqlDbType=SqlDbType.VarChar,SqlValue=Codigo},
                    };
                    var Dr = Ado.ExecDataReaderProc("usp_BuscarCliente", Paramaters);
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
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Codigo"] != DBNull.Value) { Entity.Codigo = (string)Dr["Codigo"]; }
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
        public List<ListaCliente> BuscarClienteDesc(string Codigo)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    List<ListaCliente> List = new List<ListaCliente>();
                    var Paramaters = new SqlParameter[]
                    {
                       new SqlParameter{ParameterName="@Codigo",SqlDbType=SqlDbType.VarChar,SqlValue=Codigo},
                    };
                    var Dr = Ado.ExecDataReaderProc("usp_BuscarClienteDesc", Paramaters);
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
                            if (Dr["FechaFin"] != DBNull.Value) { Entity.FechaFin = (DateTime)Dr["FechaFin"]; }
                            if (Dr["Codigo"] != DBNull.Value) { Entity.Codigo = (string)Dr["Codigo"]; }
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
                        new SqlParameter{ParameterName="@ApellidoPat",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.ApellidoPat},
                        new SqlParameter{ParameterName="@ApellidoMat",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.ApellidoMat},
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
                        new SqlParameter{ParameterName="@ApellidoPat",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.ApellidoPat},
                        new SqlParameter{ParameterName="@ApellidoMat",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.ApellidoMat},
                        new SqlParameter{ParameterName="@Dni",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Dni},
                        new SqlParameter{ParameterName="@Telefono",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.Telefono},
                        new SqlParameter{ParameterName="@TelefonoRef",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.TelefonoRef},
                        new SqlParameter{ParameterName="@FechaFin",SqlDbType=SqlDbType.Date,SqlValue=RequestBE.FechaFin},
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
        public bool DeleteCliente(DeleteClienteRequest  RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@IdCliente",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.IdCliente},
                        
                    };
                    var Dr = Ado.ExecNonQueryProc("usp_DeleteCliente", paramaters);
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        public bool ActivateCliente(DeleteClienteRequest RequestBE)
        {
            using (var Ado = new SQLServer(GeneralModel.ConnectionString))
            {
                try
                {
                    var paramaters = new SqlParameter[]
                    {
                        new SqlParameter{ParameterName="@IdCliente",SqlDbType=SqlDbType.VarChar,SqlValue=RequestBE.IdCliente},

                    };
                    var Dr = Ado.ExecNonQueryProc("usp_ActivarCliente", paramaters);
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