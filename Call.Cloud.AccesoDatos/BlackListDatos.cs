using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Call.Cloud.Modelo;

namespace Call.Cloud.AccesoDatos
{
    public class BlackListDatos : IGeneralDatos<BlackList>
    {
        public async Task<int> Delete(SqlConnection Cn, BlackList Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspDeleteBlackList",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pk", Item.pk);
            param1.Direction = ParameterDirection.Input;

            rpta = await cmd.ExecuteNonQueryAsync();
            return rpta;
            
        }

        public async Task<BlackList> Find(SqlConnection Cn, BlackList Item)
        {
            BlackList black = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspBlackListById",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pk", Item.pk);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    black = new BlackList();
                    while (await dtr.ReadAsync())
                    {
                        black = (new BlackList
                        {
                            pk = !dtr.IsDBNull(dtr.GetOrdinal("pk")) ? dtr.GetInt32(dtr.GetOrdinal("pk")) : 0,
                            word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            PkenterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("Enterprise")) : 0,
                            
                        });
                    }
                }

            }
            return black;
        }

        public async Task<int> Insert(SqlConnection Cn, BlackList Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspModificar_BlackList",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@cods", Item.pk);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@texto", Item.word ?? "");
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@enterprise", Item.PkenterPrise);
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param4.Direction = ParameterDirection.Output;

            rpta = await cmd.ExecuteNonQueryAsync();
            if (rpta > 0)
            
                return cmd.Parameters["@pOutVal"].Value!= null?(int)cmd.Parameters["@pOutVal"].Value: -1;
            
            return rpta;
            
        }

        public async Task<IEnumerable<BlackList>> Retrieve(SqlConnection Cn, BlackList Item)
        {
            List<BlackList> black = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspBlackLis_Lst",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@word", Item.word ?? "");
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@enterprise", Item.PkenterPrise);
            param2.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    black = new List<BlackList>();
                    while (await dtr.ReadAsync())
                    {
                        black.Add(new BlackList
                        {
                            pk = !dtr.IsDBNull(dtr.GetOrdinal("pk")) ? dtr.GetInt32(dtr.GetOrdinal("pk")) : 0,
                            word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            enterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""

                        });
                    }
                }

            }
            return black;
            
        }

        public Task<int> Update(SqlConnection Cn, BlackList Item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlackList>> Buscar(SqlConnection Cn, BlackList Item)
        {
            List<BlackList> white = new List<BlackList>();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspBuscarBlackList",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@word", Item.word ?? "");
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    white = new List<BlackList>();
                    while (await dtr.ReadAsync())
                    {
                        white.Add(new BlackList
                        {
                            word = dtr["word"].ToString(),
                            PkenterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Enterprise")) ? dtr.GetInt32(dtr.GetOrdinal("EnterPrise")) : 0,
                            enterPrise = !dtr.IsDBNull(dtr.GetOrdinal("Name")) ? dtr.GetString(dtr.GetOrdinal("Name")) : ""
                        });
                    }
                }

            }
            return white;

        }

    }
}
