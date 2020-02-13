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
    public class SubOfficeDatos//:IGeneralDatos<SubOffice>
    {

        //public async Task<int> Insert(SqlConnection Cn, SubOffice Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSubOfficeInsUp",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_SubOffice", Item.PkSubOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pnameSubOffice", Item.nameSubOffice ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param4.Direction = ParameterDirection.Output;


        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;
        //}

  

        //public async Task<int> Update(SqlConnection Cn, SubOffice Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSubOfficeInsUp",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_SubOffice", Item.PkSubOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pnameSubOffice", Item.nameSubOffice ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param4.Direction = ParameterDirection.Output;

        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;

        //}

        public async Task<bool> SubOficinaRegistrar(SqlConnection cn, SubOffice objSubOfficeBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SUB_OFICINA_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_SubOffice", objSubOfficeBE.Pk_SubOffice);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_Office", objSubOfficeBE.Pk_Office);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@NameSubOffice", objSubOfficeBE.nameSubOffice);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@estado", objSubOfficeBE.Estado);
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

        public async Task<List<KeyValuePair<string, string>>> SubOficinaListarCombos(SqlConnection cn, Office objOficinaBE)
        {
            List<KeyValuePair<string, string>> lstOpcionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SUB_OFICINA_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Office", objOficinaBE.Pk_Office);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstOpcionBE = new List<KeyValuePair<string, string>>();
                while (await dtr.ReadAsync())
                {
                    lstOpcionBE.Add(
                        new KeyValuePair<string, string>(
                            dtr.GetString(dtr.GetOrdinal("nameSubOffice")),
                            Convert.ToString(dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")))
                            )
                        );
                }
            }
            return lstOpcionBE;
        }

        public async Task<bool> SubOficinaEliminar(SqlConnection cn, SubOffice objSubOfficeBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SUB_OFICINA_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_SubOffice", objSubOfficeBE.Pk_SubOffice);
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

        public async Task<List<SubOffice>> SubOficinaListar(SqlConnection cn, SubOffice objSubOfficeBE)
        {
            List<SubOffice> lstSubOfficeBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SUB_OFICINA_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objSubOfficeBE.Pk_Enterprise);
            cmd.Parameters.AddWithValue("@PK_Office", objSubOfficeBE.Pk_Office);
            cmd.Parameters.AddWithValue("@NameSubOffice", objSubOfficeBE.nameSubOffice ?? "");
            cmd.Parameters.AddWithValue("@estado", objSubOfficeBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstSubOfficeBE = new List<SubOffice>();
                while (await dtr.ReadAsync())
                {
                    lstSubOfficeBE.Add(new SubOffice
                    {
                        Pk_SubOffice = dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")),
                        Pk_Office = dtr.GetInt32(dtr.GetOrdinal("PK_Office")),
                        Pk_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        nameOffice = dtr.GetString(dtr.GetOrdinal("nameOffice")),
                        nameSubOffice = dtr.GetString(dtr.GetOrdinal("nameSubOffice")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstSubOfficeBE;
        }

        //public async Task<int> Delete(SqlConnection Cn, SubOffice Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSubOfficeDel",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@ppPK_SubOffice", Item.PkSubOffice);
        //    param1.Direction = ParameterDirection.Input;
        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    return rpta;
        //}

        //public async Task<IEnumerable<SubOffice>> Retrieve(SqlConnection Cn, SubOffice Item)
        //{
        //    List<SubOffice> lSubOffice = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSubOfficeLst2",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pnameSubOffice", Item.nameSubOffice ?? "");
        //    param1.Direction = ParameterDirection.Input;

        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pPK_Office", Item.PkOffice);
        //    param2.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            lSubOffice = new List<SubOffice>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lSubOffice.Add(new SubOffice
        //                {
        //                    PkSubOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_SubOffice")) ? dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")) : 0,
        //                    nameSubOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameSubOffice")) ? dtr.GetString(dtr.GetOrdinal("nameSubOffice")) : "",
        //                    nameOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameOffice")) ? dtr.GetString(dtr.GetOrdinal("nameOffice")) : "",

        //                });
        //            }
        //        }

        //    }
        //    return lSubOffice;
        //}

      




        //public async Task<SubOffice> Find(SqlConnection Cn, SubOffice Item)
        //{
        //    SubOffice oSubOffice = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSubOfficeById",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_SubOffice", Item.PkSubOffice);
        //    param1.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            oSubOffice = new SubOffice();
        //            while (await dtr.ReadAsync())
        //            {
        //                oSubOffice = (new SubOffice
        //                {
        //                    PkSubOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_SubOffice")) ? dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")) : 0,
        //                    nameSubOffice = !dtr.IsDBNull(dtr.GetOrdinal("nameSubOffice")) ? dtr.GetString(dtr.GetOrdinal("nameSubOffice")) : "",
        //                    PkOffice = !dtr.IsDBNull(dtr.GetOrdinal("Pk_Office")) ? dtr.GetInt32(dtr.GetOrdinal("Pk_Office")) : 0,

        //                });
        //            }
        //        }

        //    }
        //    return oSubOffice;

        //}

        //public Task<IEnumerable<SubOffice>> Read(SqlConnection Cn, SubOffice Item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
