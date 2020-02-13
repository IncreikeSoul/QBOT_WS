using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class SectionDatos// : IGeneralDatos<Section>
    {

        //public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Section Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionInsUpd",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Section", Item.PkSection);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pName", Item.SectionName ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Speech", Item.PkSpeech);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pdescription", Item.description);
        //    param4.Direction = ParameterDirection.Input;
        //    SqlParameter param5 = cmd.Parameters.AddWithValue("@pWeight", Item.Weight);
        //    param5.Direction = ParameterDirection.Input;
        //    SqlParameter param6 = cmd.Parameters.AddWithValue("@pTMO", Item.TMO);
        //    param6.Direction = ParameterDirection.Input;
        //    SqlParameter param7 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param7.Direction = ParameterDirection.Output;

        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;
        //}

        //public Task<int> Update(System.Data.SqlClient.SqlConnection Cn, Section Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, Section Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionDel",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Section", Item.PkSection);
        //    param1.Direction = ParameterDirection.Input;

        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    return rpta;
        //}

        //public async Task<IEnumerable<Section>> Retrieve(SqlConnection Cn, Section Item)
        //{
        //    List<Section> lSection = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionLst",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pName", Item.SectionName ?? "");
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pPKSpeech", Item.PkSpeech);
        //    param2.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            lSection = new List<Section>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lSection.Add(new Section
        //                {
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                    SectionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    description = !dtr.IsDBNull(dtr.GetOrdinal("descripcion")) ? dtr.GetString(dtr.GetOrdinal("descripcion")) : "",
        //                    Weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) : 0,
        //                    TMO = !dtr.IsDBNull(dtr.GetOrdinal("TMO")) ? dtr.GetDecimal(dtr.GetOrdinal("TMO")) : 0
        //                });
        //            }
        //        }

        //    }
        //    return lSection;
        //}

        public async Task<List<Section>> SeccionListar(SqlConnection cn, Section objSeccionBE)
        {
            List<Section> lstSectionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SECTION_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objSeccionBE.PK_Enterprise);
            cmd.Parameters.AddWithValue("@PK_Office", objSeccionBE.PK_Office);
            cmd.Parameters.AddWithValue("@PK_SubOffice", objSeccionBE.PK_SubOffice);
            cmd.Parameters.AddWithValue("@PK_Business", objSeccionBE.PK_Business);
            cmd.Parameters.AddWithValue("@PK_Speech", objSeccionBE.PK_Speech);
            cmd.Parameters.AddWithValue("@Name", objSeccionBE.NameSection ?? "");
            cmd.Parameters.AddWithValue("@estado", objSeccionBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstSectionBE = new List<Section>();
                while (await dtr.ReadAsync())
                {
                    lstSectionBE.Add(new Section
                    {
                        PK_Section = dtr.GetInt32(dtr.GetOrdinal("PK_Section")),
                        PK_Speech = dtr.GetInt32(dtr.GetOrdinal("PK_Speech")),
                        PK_Business = dtr.GetInt32(dtr.GetOrdinal("PK_Business")),
                        PK_SubOffice = dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")),
                        PK_Office = dtr.GetInt32(dtr.GetOrdinal("PK_Office")),
                        PK_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        NameSpeech = dtr.GetString(dtr.GetOrdinal("NameSpeech")),
                        NameSection = dtr.GetString(dtr.GetOrdinal("NameSection")),
                        Description = dtr.GetString(dtr.GetOrdinal("descripcion")),
                        Weight = dtr.GetDecimal(dtr.GetOrdinal("weight")),
                        TMO = dtr.GetDecimal(dtr.GetOrdinal("TMO")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstSectionBE;
        }

        public async Task<bool> SeccionEliminar(SqlConnection cn, Section objSeccionBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SECTION_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Section", objSeccionBE.PK_Section);
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

        public async Task<bool> SeccionRegistrar(SqlConnection cn, Section objSeccionBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SECTION_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Section", objSeccionBE.PK_Section);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_Speech", objSeccionBE.PK_Speech);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@name", objSeccionBE.NameSection);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@descripcion", objSeccionBE.Description);
                param4.Direction = ParameterDirection.Input;
                SqlParameter param5 = cmd.Parameters.AddWithValue("@weight", objSeccionBE.Weight);
                param5.Direction = ParameterDirection.Input;
                SqlParameter param6 = cmd.Parameters.AddWithValue("@TMO", objSeccionBE.TMO);
                param6.Direction = ParameterDirection.Input;
                SqlParameter param7 = cmd.Parameters.AddWithValue("@estado", objSeccionBE.Estado);
                param7.Direction = ParameterDirection.Input;

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

        public async Task<List<KeyValuePair<string, string>>> SectionListarCombos(SqlConnection cn, Speech objSpeechBE)
        {
            List<KeyValuePair<string, string>> lstOpcionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SECTION_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Speech", objSpeechBE.PK_Speech);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstOpcionBE = new List<KeyValuePair<string, string>>();
                while (await dtr.ReadAsync())
                {
                    lstOpcionBE.Add(
                        new KeyValuePair<string, string>(
                            dtr.GetString(dtr.GetOrdinal("name")),
                            Convert.ToString(dtr.GetInt32(dtr.GetOrdinal("PK_Speech")))
                            )
                        );
                }
            }
            return lstOpcionBE;
        }

        //public async Task<Section> Find(System.Data.SqlClient.SqlConnection Cn, Section Item)
        //{
        //    Section oSection = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionById",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Section", Item.PkSection);
        //    param1.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            oSection = new Section();
        //            while (await dtr.ReadAsync())
        //            {
        //                oSection = (new Section
        //                {
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                    SectionName = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
        //                    description = !dtr.IsDBNull(dtr.GetOrdinal("descripcion")) ? dtr.GetString(dtr.GetOrdinal("descripcion")) : "",
        //                    Weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) : 0,
        //                    TMO = !dtr.IsDBNull(dtr.GetOrdinal("TMO")) ? dtr.GetDecimal(dtr.GetOrdinal("TMO")) : 0
        //                });
        //            }
        //        }

        //    }
        //    return oSection;
        //}

        //public async Task<IEnumerable<Section>> RetrieveSectionRuleWordRule(System.Data.SqlClient.SqlConnection Cn, int id)
        //{
        //    List<Section> lSection = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspRule_Section",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pkSection", id);
        //    param1.Direction = ParameterDirection.Input;


        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            lSection = new List<Section>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lSection.Add(new Section
        //                {
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
        //                    PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                    SectionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
        //                    NameRule = !dtr.IsDBNull(dtr.GetOrdinal("NameRule")) ? dtr.GetString(dtr.GetOrdinal("NameRule")) : "",
        //                    wieght = !dtr.IsDBNull(dtr.GetOrdinal("wieght")) ? dtr.GetDecimal(dtr.GetOrdinal("wieght")) : 0,
        //                    Status = true
        //                });
        //            }
        //        }
        //    }
        //    return lSection;
        //}


        //public async Task<IEnumerable<Section>> RetrieveDrop(SqlConnection Cn, Section Item)
        //{
        //    List<Section> lSection = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionDrop",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pSectionName", (Item != null) ? Item.SectionName : "");
        //    param1.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        lSection = new List<Section>();
        //        while (await dtr.ReadAsync())
        //        {
        //            lSection.Add(new Section()
        //            {
        //                PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                SectionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : ""
        //            });
        //        }
        //    }
        //    return lSection;
        //}

    }
}
