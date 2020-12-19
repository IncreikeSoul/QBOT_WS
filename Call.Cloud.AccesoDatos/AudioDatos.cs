using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class AudioDatos//:IGeneralDatos<AudioEva>
    {
        public async Task<List<AudioEva>> EvaluacionAudioListar(SqlConnection cn, AudioEva objAudioBE)
        {
            List<AudioEva> lstEvaAudioBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_EVALUACION_AUDIO_LISTAR",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Enterprise", objAudioBE.PK_Enterprise);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@PK_Office", objAudioBE.PK_Office);
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@PK_SubOffice", objAudioBE.PK_SubOffice);
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@FK_Business", objAudioBE.FK_Business);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@FK_Speech", objAudioBE.FK_Speech);
            param5.Direction = ParameterDirection.Input;
            SqlParameter param6 = cmd.Parameters.AddWithValue("@FK_Agent", objAudioBE.FK_Agent);
            param6.Direction = ParameterDirection.Input;
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEvaAudioBE = new List<AudioEva>();
                if (dtr != null)
                {
                    while (await dtr.ReadAsync())
                    {
                        try
                        {
                            lstEvaAudioBE.Add(new AudioEva
                            {
                                PK_audio = !dtr.IsDBNull(dtr.GetOrdinal("PK_audio")) ? dtr.GetInt32(dtr.GetOrdinal("PK_audio")) : 0,
                                FK_Agent = !dtr.IsDBNull(dtr.GetOrdinal("FK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Agent")) : 0,
                                FK_Speech = !dtr.IsDBNull(dtr.GetOrdinal("FK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Speech")) : 0,
                                FK_Business = !dtr.IsDBNull(dtr.GetOrdinal("FK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Business")) : 0,
                                PK_SubOffice = !dtr.IsDBNull(dtr.GetOrdinal("PK_SubOffice")) ? dtr.GetInt32(dtr.GetOrdinal("PK_SubOffice")) : 0,
                                PK_Office = !dtr.IsDBNull(dtr.GetOrdinal("PK_Office")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Office")) : 0,
                                PK_Enterprise = !dtr.IsDBNull(dtr.GetOrdinal("PK_Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Enterprise")) : 0,
                                duracion = !dtr.IsDBNull(dtr.GetOrdinal("duracion")) ? dtr.GetString(dtr.GetOrdinal("duracion")) : "",
                                dateCreated = !dtr.IsDBNull(dtr.GetOrdinal("dateCreated")) ? dtr.GetDateTime(dtr.GetOrdinal("dateCreated")).ToShortDateString() + 
                                                                                             " - " + dtr.GetDateTime(dtr.GetOrdinal("dateCreated")).ToLongTimeString() : "",
                                filesize = !dtr.IsDBNull(dtr.GetOrdinal("filesize")) ? dtr.GetString(dtr.GetOrdinal("filesize")) : "",
                                transcription = !dtr.IsDBNull(dtr.GetOrdinal("transcription")) ? dtr.GetString(dtr.GetOrdinal("transcription")) : "",
                                fileName = !dtr.IsDBNull(dtr.GetOrdinal("fileName")) ? dtr.GetString(dtr.GetOrdinal("fileName")) : "",
                                porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("porcentaje")) ? dtr.GetString(dtr.GetOrdinal("porcentaje")) : ""
                            });
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                    }
                }
            }
            return lstEvaAudioBE;
        }

        public async Task<List<Evaluacion>> EvaluacionSectionListar(SqlConnection cn, Evaluacion objEvaluacionBE)
        {
            List<Evaluacion> lstEvaluacionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_EVALUACION_SECTION",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_audio", objEvaluacionBE.PK_Audio);
            param1.Direction = ParameterDirection.Input;
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEvaluacionBE = new List<Evaluacion>();
                if (dtr != null)
                {
                    while (await dtr.ReadAsync())
                    {
                        try
                        {
                            lstEvaluacionBE.Add(new Evaluacion
                            {
                                PK_Section = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
                                nom_section = !dtr.IsDBNull(dtr.GetOrdinal("nom_section")) ? dtr.GetString(dtr.GetOrdinal("nom_section")) : "",
                                descripcion = !dtr.IsDBNull(dtr.GetOrdinal("descripcion")) ? dtr.GetString(dtr.GetOrdinal("descripcion")) : "",
                                weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetString(dtr.GetOrdinal("weight")) : "",
                                porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("porcentaje")) ? dtr.GetString(dtr.GetOrdinal("porcentaje")) : ""
                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    }
                }
            }
            return lstEvaluacionBE;
        }

        public async Task<List<Evaluacion>> EvaluacionRulesListar(SqlConnection cn, Evaluacion objEvaluacionBE)
        {
            List<Evaluacion> lstEvaluacionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_EVALUACION_RULES",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_audio", objEvaluacionBE.PK_Audio);
            param1.Direction = ParameterDirection.Input;
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEvaluacionBE = new List<Evaluacion>();
                if (dtr != null)
                {
                    while (await dtr.ReadAsync())
                    {
                        try
                        {
                            lstEvaluacionBE.Add(new Evaluacion
                            {
                                PK_Rule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
                                nom_rules = !dtr.IsDBNull(dtr.GetOrdinal("nom_rules")) ? dtr.GetString(dtr.GetOrdinal("nom_rules")) : "",
                                weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetString(dtr.GetOrdinal("weight")) : "",
                                word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                                porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("porcentaje")) ? dtr.GetString(dtr.GetOrdinal("porcentaje")) : ""
                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    }
                }
            }
            return lstEvaluacionBE;
        }

        public async Task<List<Evaluacion>> EvaluacionDiccionarioListar(SqlConnection cn)
        {
            List<Evaluacion> lstEvaluacionBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_EVALUACION_WORDRULE",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEvaluacionBE = new List<Evaluacion>();
                if (dtr != null)
                {
                    while (await dtr.ReadAsync())
                    {
                        try
                        {
                            lstEvaluacionBE.Add(new Evaluacion
                            {
                                PK_WordRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_WordRule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_WordRule")) : 0,
                                nom_section = !dtr.IsDBNull(dtr.GetOrdinal("nom_section")) ? dtr.GetString(dtr.GetOrdinal("nom_section")) : "",
                                nom_rules = !dtr.IsDBNull(dtr.GetOrdinal("nom_rules")) ? dtr.GetString(dtr.GetOrdinal("nom_rules")) : "",
                                word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                                weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetString(dtr.GetOrdinal("weight")) : ""
                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    }
                }
            }
            return lstEvaluacionBE;
        }

    }
}
