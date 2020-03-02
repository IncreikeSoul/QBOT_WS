using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Call.Cloud.Modelo;
using System.Data;

namespace Call.Cloud.AccesoDatos
{
    public class BusinessDatos// : IGeneralDatos<Business>
    {
        //public Task<int> Delete(SqlConnection Cn, Business Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Business> Find(SqlConnection Cn, Business Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> Insert(SqlConnection Cn, Business Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Business>> Retrieve(SqlConnection Cn, Business Item)
        //{
        //    List<Business> lEnterprise = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspBusiness",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };

        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_SubOffice", (Item != null ? Item.PK_SubOffice : 0));
        //    param1.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        lEnterprise = new List<Business>();
        //        while (await dtr.ReadAsync())
        //        {
        //            lEnterprise.Add(new Business
        //            {
        //                PK_Business = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0,
        //                nameBusiness = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : ""
        //            });
        //        }
        //    }
        //    return lEnterprise;
        //}

        public async Task<bool> NegocioEliminar(SqlConnection cn, Business objNegocioBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_NEGOCIO_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Business", objNegocioBE.PK_Business);
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

        public async Task<List<KeyValuePair<string, string>>> NegocioListarCombos(SqlConnection cn, SubOffice objSubOficinaBE)
        {
            List<KeyValuePair<string, string>> lstOpcionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_NEGOCIO_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_SubOffice", objSubOficinaBE.Pk_SubOffice);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstOpcionBE = new List<KeyValuePair<string, string>>();
                while (await dtr.ReadAsync())
                {
                    lstOpcionBE.Add(
                        new KeyValuePair<string, string>(
                            dtr.GetString(dtr.GetOrdinal("name")),
                            Convert.ToString(dtr.GetInt32(dtr.GetOrdinal("PK_Business")))
                            )
                        );
                }
            }
            return lstOpcionBE;
        }

        public async Task<bool> NegocioRegistrar(SqlConnection cn, Business objNegocioBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_NEGOCIO_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Business", objNegocioBE.PK_Business);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_SubOffice", objNegocioBE.Pk_SubOffice);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Name", objNegocioBE.nameBusiness);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@estado", objNegocioBE.Estado);
                param4.Direction = ParameterDirection.Input;

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

        public async Task<List<Business>> NegocioListar(SqlConnection cn, Business objNegocioBE)
        {
            List<Business> lstBusinessBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_NEGOCIO_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objNegocioBE.Pk_Enterprise);
            cmd.Parameters.AddWithValue("@PK_SubOffice", objNegocioBE.Pk_SubOffice);
            cmd.Parameters.AddWithValue("@PK_Office", objNegocioBE.Pk_Office);
            cmd.Parameters.AddWithValue("@Name", objNegocioBE.nameBusiness ?? "");
            cmd.Parameters.AddWithValue("@estado", objNegocioBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstBusinessBE = new List<Business>();
                while (await dtr.ReadAsync())
                {
                    lstBusinessBE.Add(new Business
                    {
                        PK_Business = dtr.GetInt32(dtr.GetOrdinal("PK_Business")),
                        Pk_SubOffice = dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")),
                        Pk_Office = dtr.GetInt32(dtr.GetOrdinal("PK_Office")),
                        Pk_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        nameOffice = dtr.GetString(dtr.GetOrdinal("nameOffice")),
                        nameSubOffice = dtr.GetString(dtr.GetOrdinal("nameSubOffice")),
                        nameBusiness = dtr.GetString(dtr.GetOrdinal("name")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstBusinessBE;
        }

        public Task<int> Update(SqlConnection Cn, Business Item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Business>> RetrieveActive(SqlConnection Cn, Business Item)
        {
            List<Business> lEnterprise = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspBusinessLst",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lEnterprise = new List<Business>();
                while (await dtr.ReadAsync())
                {
                    lEnterprise.Add(new Business
                    {
                        PK_Business = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0,
                        nameBusiness = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : ""
                    });
                }
            }
            return lEnterprise;
        }
    }
    
}

