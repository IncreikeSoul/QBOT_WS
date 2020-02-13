using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class SpeechDatos//:IGeneralDatos<Speech>
    {

        //public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Speech Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSpeechInsUpd",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Speech", Item.PkSpeech);
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pName", Item.Name);
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pDescription", Item.Description);
        //    param3.Direction = ParameterDirection.Input;
        //    SqlParameter param4 = cmd.Parameters.AddWithValue("@pPK_business", Item.PK_Business);
        //    param4.Direction = ParameterDirection.Input;          
        //    SqlParameter param5 = cmd.Parameters.AddWithValue("@pOutVal", 0);
        //    param5.Direction = ParameterDirection.Output;

        //    rpta = await cmd.ExecuteNonQueryAsync();
        //    if (rpta > 0)
        //        return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

        //    return rpta;
        //}

        public async Task<List<ReporteDatos>> ListarAudioSpeechAsync(SqlConnection cn, Speech objSpeechBE)
        {
            List<ReporteDatos> lstReporteBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_LISTAR_AUDIO_POR_SPEECH",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Business", objSpeechBE.PK_Business);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_Speech", objSpeechBE.PK_Speech);
            param2.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync())
            {
                if (dtr != null)
                {
                    lstReporteBE = new List<ReporteDatos>();
                    ReporteDatos objReporteBE = null;
                    while (await dtr.ReadAsync())
                    {
                        objReporteBE = new ReporteDatos();
                        objReporteBE.PK_Speech = Convert.ToInt32(dtr["PK_Speech"]);
                        objReporteBE.PK_audio = Convert.ToInt32(dtr["PK_audio"]);
                        objReporteBE.TX_Business = Convert.ToString(dtr["TX_Business"]);
                        objReporteBE.TX_Speech = Convert.ToString(dtr["TX_Speech"]);
                        objReporteBE.TX_Transcripcion = Convert.ToString(dtr["TX_Transcripcion"]);
                        objReporteBE.NU_WordWeight = Convert.ToDecimal(dtr["NU_WordWeight"]) * 100;

                        lstReporteBE.Add(objReporteBE);

                    }
                }
            }

            return lstReporteBE;
        }

        public async Task<List<ReporteDatos>> ListarAudioDetalleAsync(SqlConnection cn, AudioWts objAudio)
        {
            List<ReporteDatos> lstReporteBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_LISTAR_AUDIO_DETALLE",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_audio", objAudio.PK_audio);
            param1.Direction = ParameterDirection.Input;
            
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync())
            {
                if (dtr != null)
                {
                    lstReporteBE = new List<ReporteDatos>();
                    ReporteDatos objReporteBE = null;
                    while (await dtr.ReadAsync())
                    {
                        objReporteBE = new ReporteDatos();
                        objReporteBE.PK_Speech = Convert.ToInt32(dtr["PK_Speech"]);
                        objReporteBE.PK_audio = Convert.ToInt32(dtr["PK_audio"]);
                        objReporteBE.TX_Speech = Convert.ToString(dtr["TX_Speech"]);
                        objReporteBE.TX_Transcripcion = Convert.ToString(dtr["TX_Transcripcion"]);
                        objReporteBE.TX_Section = Convert.ToString(dtr["TX_Section"]);
                        objReporteBE.NU_SectionWeight = Convert.ToDecimal(dtr["NU_SectionWeight"]) * 100;
                        objReporteBE.TX_Rule = Convert.ToString(dtr["TX_Rule"]);
                        objReporteBE.NU_RuleWeight = Convert.ToDecimal(dtr["NU_RuleWeight"]) * 100;
                        objReporteBE.TX_Word = Convert.ToString(dtr["TX_Word"]);
                        objReporteBE.TX_WordAudio = Convert.ToString(dtr["TX_WordAudio"]);
                        objReporteBE.NU_WordWeight= Convert.ToDecimal(dtr["NU_WordWeight"]) * 100;

                        lstReporteBE.Add(objReporteBE);
                    }
                }
            }

            return lstReporteBE;
        }

        public async Task<List<KeyValuePair<string, string>>> SpeechListarCombos(SqlConnection cn, Business objNegocioBE)
        {
            List<KeyValuePair<string, string>> lstOpcionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SPEECH_COMBO",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@FK_business", objNegocioBE.PK_Business);
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

        public async Task<List<Speech>> SpeechListar(SqlConnection cn, Speech objSpeechBE)
        {
            List<Speech> lstSpeechBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_SPEECH_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@PK_Enterprise", objSpeechBE.PK_Enterprise);
            cmd.Parameters.AddWithValue("@PK_Office", objSpeechBE.PK_Office);
            cmd.Parameters.AddWithValue("@PK_SubOffice", objSpeechBE.PK_SubOffice);
            cmd.Parameters.AddWithValue("@PK_Business", objSpeechBE.PK_Business);
            cmd.Parameters.AddWithValue("@Name", objSpeechBE.NameSpeech ?? "");
            cmd.Parameters.AddWithValue("@estado", objSpeechBE.Estado);
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstSpeechBE = new List<Speech>();
                while (await dtr.ReadAsync())
                {
                    lstSpeechBE.Add(new Speech
                    {
                        PK_Speech = dtr.GetInt32(dtr.GetOrdinal("PK_Speech")),
                        PK_Business = dtr.GetInt32(dtr.GetOrdinal("PK_Business")),
                        PK_SubOffice = dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")),
                        PK_Office = dtr.GetInt32(dtr.GetOrdinal("PK_Office")),
                        PK_Enterprise = dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")),
                        NameOffice = dtr.GetString(dtr.GetOrdinal("nameOffice")),
                        NameSubOffice = dtr.GetString(dtr.GetOrdinal("nameSubOffice")),
                        NameBusiness = dtr.GetString(dtr.GetOrdinal("nameBusiness")),
                        NameSpeech = dtr.GetString(dtr.GetOrdinal("nameSpeech")),
                        Description = dtr.GetString(dtr.GetOrdinal("description")),
                        Estado = dtr.GetInt32(dtr.GetOrdinal("estado")),
                        Tx_Estado = dtr.GetString(dtr.GetOrdinal("Tx_Estado"))
                    });
                }
            }
            return lstSpeechBE;
        }

        public async Task<bool> SpeechEliminar(SqlConnection cn, Speech objSpeechBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SPEECH_ELIMINAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Speech", objSpeechBE.PK_Speech);
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

        public async Task<bool> SpeechRegistrar(SqlConnection cn, Speech objSpeechBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_SPEECH_REGISTRAR",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Speech", objSpeechBE.PK_Speech);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@FK_business", objSpeechBE.PK_Business);
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@name", objSpeechBE.NameSpeech);
                param3.Direction = ParameterDirection.Input;
                SqlParameter param4 = cmd.Parameters.AddWithValue("@description", objSpeechBE.Description);
                param4.Direction = ParameterDirection.Input;
                SqlParameter param5 = cmd.Parameters.AddWithValue("@estado", objSpeechBE.Estado);
                param5.Direction = ParameterDirection.Input;

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

        //public Task<int> Update(System.Data.SqlClient.SqlConnection Cn, Speech Item)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, Speech Item)
        //{
        //    int rpta = -1;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSpeechDel",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Speech", Item.PkSpeech);
        //    param1.Direction = ParameterDirection.Input;
         

        //    rpta = await cmd.ExecuteNonQueryAsync();            

        //    return rpta;
        //}

        //public async Task<IEnumerable<Speech>> Retrieve(System.Data.SqlClient.SqlConnection Cn, Speech Item)
        //{
        //    List<Speech> lSpeech = null;
        //    List<Section> lSection = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSpeechLst",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pName", Item.Name ?? "");
        //    param1.Direction = ParameterDirection.Input;
        //    SqlParameter param2 = cmd.Parameters.AddWithValue("@pDescription", Item.Description ?? "");
        //    param2.Direction = ParameterDirection.Input;
        //    SqlParameter param3 = cmd.Parameters.AddWithValue("@pFk_Business", Item.PK_Business);
        //    param3.Direction = ParameterDirection.Input;

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync())
        //    {
        //        if (dtr != null)
        //        {
        //            lSpeech = new List<Speech>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lSpeech.Add(new Speech
        //                {
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    Description = !dtr.IsDBNull(dtr.GetOrdinal("description")) ? dtr.GetString(dtr.GetOrdinal("description")) : "",
        //                    nameBusiness = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
        //                    Status = false
        //                });

        //            }
        //            //if (await dtr.NextResultAsync())
        //            //{
        //            //    lSection = new List<Section>();
        //            //    while (await dtr.ReadAsync())
        //            //    {
        //            //        lSection.Add(new Section
        //            //        {
        //            //            PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //            //            SectionName= !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : ""
        //            //        });
        //            //    }

        //            //}

        //        }
        //        //lSpeech.ForEach(x =>
        //        //   {                       
        //        //       lSection.ForEach(y =>
        //        //           {
        //        //               if (x.PkSpeech == y.PkSpeech)
        //        //                   x.PkSection = y.PkSection;
        //        //           });

        //        //   });
        //    }
            
        //    return lSpeech;
        //}

        //public async Task<Speech> Find(System.Data.SqlClient.SqlConnection Cn, Speech Item)
        //{
        //    Speech oSpeech = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSpeechById",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Speech", Item.PkSpeech);
        //    param1.Direction = ParameterDirection.Input;         

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            oSpeech = new Speech();
        //            while (await dtr.ReadAsync())
        //            {
        //                oSpeech=(new Speech
        //                {
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    Name = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
        //                    Description = !dtr.IsDBNull(dtr.GetOrdinal("description")) ? dtr.GetString(dtr.GetOrdinal("description")) : "",
        //                    PK_Business = !dtr.IsDBNull(dtr.GetOrdinal("Fk_business")) ? dtr.GetInt32(dtr.GetOrdinal("Fk_business")) :0

        //                });
        //            }
        //        }

        //    }
        //    return oSpeech;
        //}
        //public async Task<IEnumerable<Speech>> RetrieveSectionSpeech(System.Data.SqlClient.SqlConnection Cn, int id)
        //{
        //    List<Speech> lSpeech = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspSectionSpeechLstById",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pPKSection", id);
        //    param1.Direction = ParameterDirection.Input;
          

        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.Default))
        //    {
        //        if (dtr != null)
        //        {
        //            lSpeech = new List<Speech>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lSpeech.Add(new Speech
        //                {
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                    SectionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
        //                    descripcion = !dtr.IsDBNull(dtr.GetOrdinal("descripcion")) ? dtr.GetString(dtr.GetOrdinal("descripcion")) : "",
        //                    WeightSection = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) :0,
        //                    Status = true,
        //                    TMO = !dtr.IsDBNull(dtr.GetOrdinal("TMO")) ? dtr.GetDecimal(dtr.GetOrdinal("TMO")) : 0
        //                });
        //            } 
        //        }
        //    }
        //    return lSpeech;
        //}


    }
}
