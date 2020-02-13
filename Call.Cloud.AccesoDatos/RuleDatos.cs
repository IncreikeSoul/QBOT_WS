using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Call.Cloud.Modelo;

namespace Call.Cloud.AccesoDatos
{
    public class RuleDatos : IGeneralDatos<Modelo.Rule>
    {

        public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Modelo.Rule Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspRuleInsUpd",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pPK_Section", Item.PkSection);
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pName", Item.NameRule ?? "");
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@pTime_Rule", Item.TimeRule);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@pWieght", Item.wieght);
            param5.Direction = ParameterDirection.Input;
            SqlParameter param6 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param6.Direction = ParameterDirection.Output;

            rpta = await cmd.ExecuteNonQueryAsync();
            if (rpta > 0)
                return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

            return rpta;
        }

        public Task<int> Update(SqlConnection Cn, Modelo.Rule Item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(SqlConnection Cn, Modelo.Rule Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspRuleDel",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param1.Direction = ParameterDirection.Input;

            rpta = await cmd.ExecuteNonQueryAsync();

            return rpta;
        }

        //eliminar dentro del mantenimiento speech
        public async Task<Modelo.Rule> DeleteRule(SqlConnection Cn, Modelo.Rule Item)
        {
            Modelo.Rule lRule = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspRuleDel",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lRule = new Modelo.Rule();
                    while (await dtr.ReadAsync())
                    {
                        lRule = (new Modelo.Rule
                        {
                            PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0
                        });
                    }
                }

            }

            return lRule;
        }

        public async Task<IEnumerable<Modelo.Rule>> Retrieve(SqlConnection Cn, Modelo.Rule Item)
        {
            List<Modelo.Rule> lRule = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspRuleLst",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pPK_Section", Item.PkSection);
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pName", Item.NameRule ?? "");
            param3.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lRule = new List<Modelo.Rule>();
                    while (await dtr.ReadAsync())
                    {
                        lRule.Add(new Modelo.Rule
                        {
                            PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
                            NameRule = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
                            SeccionName = !dtr.IsDBNull(dtr.GetOrdinal("SeccionName")) ? dtr.GetString(dtr.GetOrdinal("SeccionName")) : "",
                            TimeRule = !dtr.IsDBNull(dtr.GetOrdinal("time_rule")) ? dtr.GetDecimal(dtr.GetOrdinal("time_rule")) : 0,
                            wieght = !dtr.IsDBNull(dtr.GetOrdinal("wieght")) ? dtr.GetDecimal(dtr.GetOrdinal("wieght")) : 0
                        });
                    }
                }

            }
            return lRule;
        }

        public async Task<Modelo.Rule> Find(SqlConnection Cn, Modelo.Rule Item)
        {
            Modelo.Rule oRule = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspRuleById",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    oRule = new Modelo.Rule();
                    while (await dtr.ReadAsync())
                    {
                        oRule = (new Modelo.Rule
                        {
                            PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
                            SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
                            PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
                            NameRule = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
                            PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
                            SeccionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
                            TimeRule = !dtr.IsDBNull(dtr.GetOrdinal("time_rule")) ? dtr.GetDecimal(dtr.GetOrdinal("time_rule")) : 0,
                            wieght = !dtr.IsDBNull(dtr.GetOrdinal("wieght")) ? dtr.GetDecimal(dtr.GetOrdinal("wieght")) : 0,
                            Status=true
                        });
                    }
                }

            }
            return oRule;
        }
        //este no uso
        //public async Task<IEnumerable<Modelo.Rule>> ListarWordRule(System.Data.SqlClient.SqlConnection Cn, int id)
        //{
        //    List<Modelo.Rule> lRule = null;
        //    SqlCommand cmd = new SqlCommand
        //    {
        //        CommandText = "uspWordRuleByRule",
        //        CommandType = CommandType.StoredProcedure,
        //        Connection = Cn
        //    };
        //    SqlParameter param1 = cmd.Parameters.AddWithValue("@pkRule", id);
        //    param1.Direction = ParameterDirection.Input;


        //    using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
        //    {
        //        if (dtr != null)
        //        {
        //            lRule = new List<Modelo.Rule>();
        //            while (await dtr.ReadAsync())
        //            {
        //                lRule.Add(new Modelo.Rule
        //                {
        //                    PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
        //                    PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
        //                    SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
        //                    PkSection = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
        //                    SeccionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
        //                    PkWordRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_WordRule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_WordRule")) : 0,
        //                    Word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
        //                    wieght = !dtr.IsDBNull(dtr.GetOrdinal("wieght")) ? dtr.GetDecimal(dtr.GetOrdinal("wieght")) : 0,
        //                    Sequence = !dtr.IsDBNull(dtr.GetOrdinal("sequence")) ? dtr.GetInt32(dtr.GetOrdinal("sequence")) : 0,
        //                    Status = true
        //                });
        //            }
        //        }
        //    }
        //    return lRule;
        //}
    }
}
