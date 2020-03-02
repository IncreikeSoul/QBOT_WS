using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Call.Cloud.AccesoDatos 
{
    public class EnterpriseDatos
    {
        //public async Task<IEnumerable<Enterprise>> Retrieve(SqlConnection Cn, Enterprise Item)
        //{
        //    List<Enterprise> lEnterprise = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspEnterprise",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        lEnterprise = new List<Enterprise>();
        //        while (await dtr.ReadAsync())
        //        {
        //            lEnterprise.Add(new Enterprise
        //            {
        //                PkenterPrise=!dtr.IsDBNull(dtr.GetOrdinal("PK_Enterprise"))?dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")):0,
        //                enterPrise= !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""
        //            });
        //        }
        //    }
        //    return lEnterprise;
        //}

        public async Task<bool> EmpresaRegistrar(SqlConnection cn, Enterprise objEnterpriseBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_ENTERPRISE_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Enterprise", objEnterpriseBE.Pk_Enterprise);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Name", objEnterpriseBE.Name);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@estado", objEnterpriseBE.Estado);
                param3.Direction = ParameterDirection.Input;

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
        }

        public async Task<bool> EmpresaEliminar(SqlConnection cn, Enterprise objEnterpriseBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_ENTERPRISE_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Enterprise", objEnterpriseBE.Pk_Enterprise);
                param1.Direction = ParameterDirection.Input;

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
        }

        public List<KeyValuePair<string, string>> EmpresaListarCombo(SqlConnection cn)
        {
            List<KeyValuePair<string, string>> lstEnterpriseBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_ENTERPRISE_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            using (SqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                lstEnterpriseBE = new List<KeyValuePair<string, string>>();
                while (dtr.Read())
                {
                    lstEnterpriseBE.Add(
                        new KeyValuePair<string, string>(
                            dtr.GetString(dtr.GetOrdinal("Name")),
                            Convert.ToString(dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")))
                            )
                        );
                }
            }
            return lstEnterpriseBE;
        }

        public async Task<List<Enterprise>> EmpresaListar(SqlConnection cn, Enterprise objEnterpriseBE)
        {
            List<Enterprise> lstEnterpriseBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_ENTERPRISE_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@Name", objEnterpriseBE.Name ?? "");
            cmd.Parameters.AddWithValue("@estado", objEnterpriseBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEnterpriseBE = new List<Enterprise>();
                while (await dtr.ReadAsync())
                {
                    lstEnterpriseBE.Add(new Enterprise
                    {
                        Pk_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        Name = dtr.GetString(dtr.GetOrdinal("Name")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstEnterpriseBE;
        }

        //public List<Enterprise> Listar(SqlConnection Cn)
        //{
        //    List<Enterprise> lEnterprise = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspEnterprise",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    using (SqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        //    {
        //        lEnterprise = new List<Enterprise>();
        //        while (dtr.Read())
        //        {
        //            lEnterprise.Add(new Enterprise
        //            {
        //                PkenterPrise = !dtr.IsDBNull(dtr.GetOrdinal("PK_Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")) : 0,
        //                enterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""
        //            });
        //        }
        //    }
        //    return lEnterprise;
        //}

        public async Task<bool> GuardarFTPAsync(SqlConnection cn, EnterpriseFTPDatos objEnterpriseFTP)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_INS_ENTERPRISEFTP",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Enterprise", objEnterpriseFTP.PK_Enterprise);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Server", objEnterpriseFTP.Server == null ? "" : objEnterpriseFTP.Server);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Port", objEnterpriseFTP.Port == null ? "" : objEnterpriseFTP.Port);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@Folder", objEnterpriseFTP.Folder == null ? "" : objEnterpriseFTP.Folder);
                param4.Direction = ParameterDirection.Input;
                SqlParameter param5 = cmd.Parameters.AddWithValue("@Username", objEnterpriseFTP.Username == null ? "" : objEnterpriseFTP.Username);
                param5.Direction = ParameterDirection.Input;
                SqlParameter param6 = cmd.Parameters.AddWithValue("@Password", objEnterpriseFTP.Password == null ? "" : objEnterpriseFTP.Password);
                param6.Direction = ParameterDirection.Input;

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex) {
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                return false;
            }

        }

        public async Task<List<EnterpriseFTPDatos>> ListarFTP(SqlConnection cn, EnterpriseFTPDatos objEnterpriseFTP)
        {
            List<EnterpriseFTPDatos> lEnterprise = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_LST_ENTERPRISEFTP",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objEnterpriseFTP.PK_Enterprise);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lEnterprise = new List<EnterpriseFTPDatos>();
                while (await dtr.ReadAsync())
                {
                    lEnterprise.Add(new EnterpriseFTPDatos
                    {
                        PK_ftp=Convert.ToInt32(dtr["PK_ftp"]),
                        PK_Enterprise =Convert.ToInt32(dtr["PK_Enterprise"]),
                        Name = Convert.ToString(dtr["Name"]),
                        Server = Convert.ToString(dtr["Server"]),
                        Port = Convert.ToString(dtr["Port"]),
                        Folder = Convert.ToString(dtr["Folder"]),
                        Username = Convert.ToString(dtr["Username"]),
                        Password = Convert.ToString(dtr["Password"])
                    });
                }
            }
            return lEnterprise;
        }

        //public Task<int> Update(SqlConnection Cn, Enterprise Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> Insert(SqlConnection Cn, Enterprise Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> Delete(SqlConnection Cn, Enterprise Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Enterprise> Find(SqlConnection Cn, Enterprise Item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
