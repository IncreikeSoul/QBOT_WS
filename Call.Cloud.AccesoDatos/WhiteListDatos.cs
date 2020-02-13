using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Call.Cloud.Modelo;

namespace Call.Cloud.AccesoDatos
{
    public class WhiteListDatos : IGeneralDatos<WhiteList>
    {
        public async Task<int> Delete(SqlConnection Cn, WhiteList Item)
        {
            int devuelve = -1;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspdeleteWhiteList",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_word", Item.pk_word);
            param1.Direction = ParameterDirection.Input;

            devuelve = await cmd.ExecuteNonQueryAsync();

            return devuelve;
        }

        public async Task<WhiteList> Find(SqlConnection Cn, WhiteList Item)
        {
            WhiteList white = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWhiteListByid",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_word", Item.pk_word);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    white = new WhiteList();
                    while (await dtr.ReadAsync())
                    {
                        white = (new WhiteList
                        {
                            pk_word = !dtr.IsDBNull(dtr.GetOrdinal("PK_word")) ? dtr.GetInt32(dtr.GetOrdinal("PK_word")) : 0,
                            word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("Porcentaje")) ? dtr.GetDecimal(dtr.GetOrdinal("Porcentaje")) : 0,
                            PkenterPrise = !dtr.IsDBNull(dtr.GetOrdinal("EnterPrise")) ? dtr.GetInt32(dtr.GetOrdinal("EnterPrise")) : 0,

                        });
                    }
                }

            }

            return white;

        }

        public async Task<int> Insert(SqlConnection Cn, WhiteList Item)
        {
            int rpta = -1;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWhiteListUpdate",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_white", Item.pk_word);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@texto", Item.word);
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@Porcentaje", Item.porcentaje);
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@Enterprise", Item.PkenterPrise);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param5.Direction = ParameterDirection.Output;


            rpta = await cmd.ExecuteNonQueryAsync();

            if (rpta > 0)
                return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

            return rpta;

        }

        public async Task<IEnumerable<WhiteList>> Retrieve(SqlConnection Cn, WhiteList Item)
        {
            List<WhiteList> listawhite = new List<WhiteList>();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWhiteListar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            
            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listawhite = new List<WhiteList>();
                    while (await dtr.ReadAsync())
                    {
                        listawhite.Add(new WhiteList
                        {
                            pk_word = !dtr.IsDBNull(dtr.GetOrdinal("PK_word")) ? dtr.GetInt32(dtr.GetOrdinal("PK_word")) : 0,
                            word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("Porcentaje")) ? dtr.GetDecimal(dtr.GetOrdinal("Porcentaje")) : 0,
                            enterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""
                        });
                    }
                }

            }
            return listawhite;
        }

        public async Task<IEnumerable<WhiteList>> Buscar(SqlConnection Cn, WhiteList Item)
        {
            List<WhiteList> white = new List<WhiteList>();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspBuscarWhiteList",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@word", Item.word ?? "");
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    white = new List<WhiteList>();
                    while (await dtr.ReadAsync())
                    {
                        white.Add(new WhiteList
                        {
                            word = dtr["word"].ToString(),
                            porcentaje = !dtr.IsDBNull(dtr.GetOrdinal("Porcentaje")) ? dtr.GetDecimal(dtr.GetOrdinal("Porcentaje")) : 0,
                            PkenterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("EnterPrise")) : 0,
                            enterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""
                        });
                    }
                }

            }
            return white;
            
        }

        public Task<int> Update(SqlConnection Cn, WhiteList Item)
        {
            throw new NotImplementedException();
        }

        public int BuscarYhimy(SqlConnection Cn, int id)
        {
            var i = -1;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "sp_proceso",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@PK_Enterprise", id);
            param1.Direction = ParameterDirection.Input;

            i = cmd.ExecuteNonQuery();
            
            return i;

        }
    }
}
