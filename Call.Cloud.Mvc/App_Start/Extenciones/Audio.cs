using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.AudioVM;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class Audio
    {
        public async Task<IEnumerable<AudioVm>> listar_audios(AudioVm Item)
        {
            List<AudioVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "busqueda_audios_filtros",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_business", Item.PK_Business);
                param1.Direction = ParameterDirection.Input;

                SqlParameter param2 = cmd.Parameters.AddWithValue("@pk_boss", Item.Fk_Boss);
                param2.Direction = ParameterDirection.Input;

                SqlParameter param3 = cmd.Parameters.AddWithValue("@pk_agent", Item.PkAgent);
                param3.Direction = ParameterDirection.Input;
                
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr!=null)
                    {
                        mostrar = new List<AudioVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new AudioVm();
                            Item.pk_auido = !dr.IsDBNull(dr.GetOrdinal("PK_audio")) ? dr.GetInt32(dr.GetOrdinal("PK_audio")) :0;
                            Item.seconds = !dr.IsDBNull(dr.GetOrdinal("seconds")) ? dr.GetInt32(dr.GetOrdinal("seconds")) : 0;
                            Item.dateCreated = !dr.IsDBNull(dr.GetOrdinal("dateCreated")) ? dr.GetDateTime(dr.GetOrdinal("dateCreated")).ToLongTimeString() : "";
                            Item.PkAgent = !dr.IsDBNull(dr.GetOrdinal("PK_Agent")) ? dr.GetInt32(dr.GetOrdinal("PK_Agent")) : 0;
                            Item.PK_Business = !dr.IsDBNull(dr.GetOrdinal("PK_Business")) ? dr.GetInt32(dr.GetOrdinal("PK_Business")) : 0;
                            Item.Fk_Boss = !dr.IsDBNull(dr.GetOrdinal("FK_Boss")) ? dr.GetInt32(dr.GetOrdinal("FK_Boss")) : 0;
                            Item.FirstName = !dr.IsDBNull(dr.GetOrdinal("nameAB")) ? dr.GetString(dr.GetOrdinal("nameAB")) : "";
                            Item.date = !dr.IsDBNull(dr.GetOrdinal("date")) ? dr.GetDateTime(dr.GetOrdinal("date")).ToShortDateString() : "";
                            Item.nameBusiness = !dr.IsDBNull(dr.GetOrdinal("nameBusiness")) ? dr.GetString(dr.GetOrdinal("nameBusiness")) : "";                                                                                                              
                            Item.state = !dr.IsDBNull(dr.GetOrdinal("state")) ? dr.GetString(dr.GetOrdinal("state")) : "";
                            Item.direccionAudio = !dr.IsDBNull(dr.GetOrdinal("PathMinThumbnails")) ? dr.GetString(dr.GetOrdinal("PathMinThumbnails")) : "";
                            Item.fileName = !dr.IsDBNull(dr.GetOrdinal("fileName")) ? dr.GetString(dr.GetOrdinal("fileName")) : "";
                            Item.filesize = !dr.IsDBNull(dr.GetOrdinal("filesize")) ? dr.GetString(dr.GetOrdinal("filesize")) : "";
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;

        }



        public async Task<IEnumerable<AudioVm>> listar_audios_detalle(AudioVm Item)
        {
        
           List<AudioVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Audio_Detalle",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
 
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Audio",Item.pk_auido);
                param1.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<AudioVm>();
                        while (await dr.ReadAsync())
                        {

                            Item = new AudioVm();
                            Item.fileName = !dr.IsDBNull(dr.GetOrdinal("fileName")) ? dr.GetString(dr.GetOrdinal("fileName")) : "";
                            Item.text = !dr.IsDBNull(dr.GetOrdinal("text")) ? dr.GetString(dr.GetOrdinal("text")) : "";
                            Item.starSecond = !dr.IsDBNull(dr.GetOrdinal("startSecond")) ? dr.GetFloat(dr.GetOrdinal("startSecond")) : 0;
                            Item.endSecond = !dr.IsDBNull(dr.GetOrdinal("endSecond")) ? dr.GetFloat(dr.GetOrdinal("endSecond")) : 0;
                            Item.duration = !dr.IsDBNull(dr.GetOrdinal("duration")) ? dr.GetFloat(dr.GetOrdinal("duration")) : 0;
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;

        }        

    }
}