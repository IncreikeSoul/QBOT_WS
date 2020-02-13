using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaProcesamiento
{
    public class DA_AUDIO
    {
        string constr = ConfigurationManager.ConnectionStrings["CN_QBOT"].ConnectionString;

        internal bool registrarAudio(BE_TRANSCRIPCION objTranscripcionBE)
        {
            bool resultado = false;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(constr);
                conn.Open();

                cmd = new SqlCommand("dbo.spAgregarAudio", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FkBusiness", objTranscripcionBE.IdNegocio);
                cmd.Parameters.AddWithValue("@Fk_Speech", objTranscripcionBE.IdSpeech);
                cmd.Parameters.AddWithValue("@Fk_Agent", objTranscripcionBE.IdAgente);
                //cmd.Parameters.AddWithValue("@Fk_Call", objTranscripcionBE.IdCall);
                cmd.Parameters.AddWithValue("@Number", objTranscripcionBE.NumeroEntrada);
                cmd.Parameters.AddWithValue("@texto", objTranscripcionBE.Texto);
                cmd.Parameters.AddWithValue("@NombreArchivo", objTranscripcionBE.NombreArchivo);
                cmd.Parameters.AddWithValue("@FechaCreacionAudio", objTranscripcionBE.FechaCreacion);
                cmd.Parameters.AddWithValue("@WeightAudio", objTranscripcionBE.TamanoAudio);
                cmd.Parameters.AddWithValue("@RutaCompleta", objTranscripcionBE.RutaCompleta);
                cmd.Parameters.AddWithValue("@IdPkAudio", objTranscripcionBE.IdAudio).Direction=ParameterDirection.Output;
                int nuResult = cmd.ExecuteNonQuery();
                if (nuResult > 0)
                {
                    objTranscripcionBE.IdAudio = Convert.ToInt32(cmd.Parameters["@IdPkAudio"].Value);
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
            return resultado;
        }

        internal bool registrarPalabraDetalle(BE_PALABRA palabra)
        {
            bool resultado = false;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(constr);
                conn.Open();

                cmd = new SqlCommand("dbo.SP_WORDRULE_DETAIL_REGISTRAR", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_audio", palabra.PK_audio);
                cmd.Parameters.AddWithValue("@PK_WordRule", palabra.PK_WordRule);
                cmd.Parameters.AddWithValue("@PK_Rule", palabra.PK_Rule);
                cmd.Parameters.AddWithValue("@word", palabra.word);
                cmd.Parameters.AddWithValue("@sequence", 0);
                cmd.Parameters.AddWithValue("@time_word", 0);
                cmd.Parameters.AddWithValue("@weight", palabra.NU_WeightRule * palabra.NU_WeightSection);
                int nuResult = cmd.ExecuteNonQuery();
                if (nuResult > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
            return resultado;
        }

        internal List<BE_PALABRA> obtenerPalabrasSpeech(string codigoSpeech)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                List<BE_PALABRA> lstPalabraBE = new List<BE_PALABRA>();
                conn = new SqlConnection(constr);
                conn.Open();

                cmd = new SqlCommand("dbo.OBTENER_PALABRAS_POR_SPEECH", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_Speech", codigoSpeech);
                SqlDataReader sdr = cmd.ExecuteReader();
                BE_PALABRA objPalabraBE = null;
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        objPalabraBE = new BE_PALABRA();
                        objPalabraBE.PK_WordRule = Convert.ToInt32(sdr["PK_WordRule"]);
                        objPalabraBE.PK_Rule = Convert.ToInt32(sdr["PK_Rule"]);
                        objPalabraBE.word = Convert.ToString(sdr["word"]);
                        objPalabraBE.NU_WeightSection = Convert.ToDecimal(sdr["NU_WeightSection"]);
                        objPalabraBE.NU_WeightRule = Convert.ToDecimal(sdr["NU_WeightRule"]);
                        lstPalabraBE.Add(objPalabraBE);
                    }
                }
                return lstPalabraBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
        }

        internal BE_FTP obtenerDatosFtp(string codigo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(constr);
                conn.Open();

                cmd = new SqlCommand("dbo.SP_OBTENER_FTP_ID", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_ftp", codigo);
                SqlDataReader sdr = cmd.ExecuteReader();
                BE_FTP objFtpBE = null;
                if (sdr.HasRows) {
                    objFtpBE = new BE_FTP();
                    if (sdr.Read())
                    {
                        objFtpBE.IdFtp = Convert.ToInt32(sdr["PK_ftp"]);
                        objFtpBE.Server = Convert.ToString(sdr["Server"]);
                        objFtpBE.Port = Convert.ToInt32(sdr["Port"]);
                        objFtpBE.Folder = Convert.ToString(sdr["Folder"]);
                        objFtpBE.Username = Convert.ToString(sdr["Username"]);
                        objFtpBE.Password = Convert.ToString(sdr["Password"]);
                    }
                }
                return objFtpBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
        }

        internal bool registrarPalabra(BE_PALABRA objPalabraBE)
        {
            bool resultado = false;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(constr);
                conn.Open();

                cmd = new SqlCommand("dbo.spAgregarAudioTranscription", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@starSecond", objPalabraBE.Inicio);
                cmd.Parameters.AddWithValue("@endSecond", objPalabraBE.Fin);
                cmd.Parameters.AddWithValue("@text", objPalabraBE.Texto);
                cmd.Parameters.AddWithValue("@pk_audio", objPalabraBE.IdAudio);
                int nuResult = cmd.ExecuteNonQuery();
                if (nuResult > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
            return resultado;
        }
    }
}
