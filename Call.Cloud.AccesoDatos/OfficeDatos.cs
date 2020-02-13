using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//SqlParameter
using System.Data.SqlClient;//SqlCommand
using Call.Cloud.Modelo;

namespace Call.Cloud.AccesoDatos
{
    public class OfficeDatos
    {
     

        //public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Office Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeInsUp",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pnameOffice", Item.nameOffice ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Enterprise", Item.PkEnterprise);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param4.Direction = ParameterDirection.Output;


        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;
        //}

        //public async Task<int> Update(System.Data.SqlClient.SqlConnection Cn, Office Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeInsUp",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pnameOffice", Item.nameOffice ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Enterprise", Item.PkEnterprise);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param4.Direction = ParameterDirection.Output;

        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;

        //}



        //public async Task<IEnumerable<Office>> Retrieve(System.Data.SqlClient.SqlConnection Cn, Office Item)
        //{
        //    List<Office> lOffice = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeLst",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pnameOffice", Item.nameOffice ?? "");
        //    param1.Direction = ParameterDirection.Input;

        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pPK_Enterprise", Item.PkEnterprise);
        //    param2.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            lOffice = new List<Office>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lOffice.Add(new Office
        //                {
        //                    PkOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_Office")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Office")) : 0,
        //                    nameOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameOffice")) ? dtr.GetString(dtr.GetOrdinal("nameOffice")) : "",
        //                    Name = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : "",

        //                });
        //            }
        //        }

        //    }
        //    return lOffice;
        //}

        public async Task<List<Office>> OficinaListar(SqlConnection cn, Office objOfficeBE)
        {
            List<Office> lstOfficeBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_OFICINA_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objOfficeBE.Pk_Enterprise);
            cmd.Parameters.AddWithValue("@NameOffice", objOfficeBE.Name ?? "");
            cmd.Parameters.AddWithValue("@estado", objOfficeBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstOfficeBE = new List<Office>();
                while (await dtr.ReadAsync())
                {
                    lstOfficeBE.Add(new Office
                    {
                        Pk_Office = dtr.GetInt32(dtr.GetOrdinal("PK_Office")),
                        Pk_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        Name = dtr.GetString(dtr.GetOrdinal("nameOffice")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstOfficeBE;
        }

        public async  Task<List<KeyValuePair<string, string>>> OficinaListarCombos(SqlConnection cn, Enterprise objEnterpriseBE)
        {
            List<KeyValuePair<string, string>> lstOpcionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_OFICINA_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objEnterpriseBE.Pk_Enterprise);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstOpcionBE = new List<KeyValuePair<string, string>>();
                while (await dtr.ReadAsync())
                {
                    lstOpcionBE.Add(
                        new KeyValuePair<string, string>(
                            dtr.GetString(dtr.GetOrdinal("nameOffice")),
                            Convert.ToString(dtr.GetInt32(dtr.GetOrdinal("PK_Office")))
                            )
                        );
                }
            }
            return lstOpcionBE;
        }

        public async Task<bool> OficinaEliminar(SqlConnection cn, Office objOfficeBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_OFICINA_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Office", objOfficeBE.Pk_Office);
                param1.Direction = ParameterDirection.Input;

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> OficinaRegistrar(SqlConnection cn, Office objOfficeBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_OFICINA_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Office", objOfficeBE.Pk_Office);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_Enterprise", objOfficeBE.Pk_Enterprise);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@NameOffice", objOfficeBE.Name);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@estado", objOfficeBE.Estado);
                param4.Direction = ParameterDirection.Input;

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public async Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, Office Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeDel",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@ppPK_Office", Item.PkOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    return rpta;
        //}

        //public async Task<Office> Find(SqlConnection Cn, Office Item)
        //{
        //    Office oOffice = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeById",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param1.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            oOffice = new Office();
        //            while (await dtr.ReadAsync())
        //            {
        //                oOffice = (new Office
        //                {
        //                    PkOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_Office")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Office")) : 0,
        //                    nameOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameOffice")) ? dtr.GetString(dtr.GetOrdinal("nameOffice")) : "",
        //                    PkEnterprise = !dtr.IsDBNull(dtr.GetOrdinal("Pk_Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("Pk_Enterprise")) : 0,

        //                });
        //            }
        //        }

        //    }
        //    return oOffice;
        //}

        //public async Task<IEnumerable<Office>> Read(SqlConnection Cn, Office Item)
        //{
        //    List<Office> lOffice = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspOfficeLstCbo",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        lOffice = new List<Office>();
        //        while (await dtr.ReadAsync())
        //        {
        //            lOffice.Add(new Office
        //            {
        //                PkOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_Office")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Office")) : 0,
        //                nameOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameOffice")) ? dtr.GetString(dtr.GetOrdinal("nameOffice")) : ""
        //            });
        //        }
        //    }
        //    return lOffice;


        //}
    }
}
