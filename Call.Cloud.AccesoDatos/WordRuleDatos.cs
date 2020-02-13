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
    public class WordRuleDatos:IGeneralDatos<WordRule>
    {

        public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, WordRule Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWordRuleInsUpd",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_WordRule", Item.PkWorldRule);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pWord", Item.Word ?? "");
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@pSequence", Item.Sequence);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@pTime_Word", Item.TimeWord);
            param5.Direction = ParameterDirection.Input;
            SqlParameter param6 = cmd.Parameters.AddWithValue("@pWeight", Item.Weight);
            param6.Direction = ParameterDirection.Input;
            SqlParameter param7 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param7.Direction = ParameterDirection.Output;

            rpta = await cmd.ExecuteNonQueryAsync();
            if (rpta > 0)
                return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

            return rpta;
        }

        public Task<int> Update(System.Data.SqlClient.SqlConnection Cn, WordRule Item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, WordRule Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWordRuleDel",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_WordRule", Item.PkWorldRule);
            param1.Direction = ParameterDirection.Input;           
            rpta = await cmd.ExecuteNonQueryAsync();
            return rpta;
        }

        public async Task<IEnumerable<WordRule>> Retrieve(System.Data.SqlClient.SqlConnection Cn, WordRule Item)
        {
            List<WordRule> lWordRule = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWordRuleLst",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Rule", Item.PkRule);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pWord", Item.Word ?? "");
            param2.Direction = ParameterDirection.Input;


            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lWordRule = new List<WordRule>();
                    while (await dtr.ReadAsync())
                    {
                        lWordRule.Add(new WordRule
                        {
                            PkWorldRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_WordRule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_WordRule")) : 0,
                            RuleName = !dtr.IsDBNull(dtr.GetOrdinal("RuleName")) ? dtr.GetString(dtr.GetOrdinal("RuleName")) : "",
                            Word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            Sequence = !dtr.IsDBNull(dtr.GetOrdinal("sequence")) ? dtr.GetInt32(dtr.GetOrdinal("sequence")) :0,                            
                            TimeWord = !dtr.IsDBNull(dtr.GetOrdinal("time_word")) ? dtr.GetDecimal(dtr.GetOrdinal("time_word")) : 0,
                            Weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) : 0,
                            PkRule= !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0
                        });
                    }
                }

            }
            return lWordRule;
        }
        

        public async Task<WordRule> Find(System.Data.SqlClient.SqlConnection Cn, WordRule Item)
        {
            WordRule oWordRule = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWordRuleById",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_WordRule", Item.PkWorldRule);
            param1.Direction = ParameterDirection.Input;         


            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    oWordRule = new WordRule();
                    while (await dtr.ReadAsync())
                    {
                        oWordRule = (new WordRule
                        {
                            PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
                            SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
                            fk_Section = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
                            PkWorldRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_WordRule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_WordRule")) : 0,
                            PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
                            Sequence = !dtr.IsDBNull(dtr.GetOrdinal("sequence")) ? dtr.GetInt32(dtr.GetOrdinal("sequence")) : 0,
                            Word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                            TimeWord = !dtr.IsDBNull(dtr.GetOrdinal("time_word")) ? dtr.GetDecimal(dtr.GetOrdinal("time_word")) : 0,
                            Weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) : 0,
                            Status = true
                        });
                    }
                }

            }
            return oWordRule;
        }

        //este es el que uso ;)
        public async Task<IEnumerable<WordRule>> ListarWordRule(SqlConnection Cn, int id)
        {
            List<WordRule> lRule = null;
            WordRule item = new WordRule();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspWordRuleByRule",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pkSection", id);
            param1.Direction = ParameterDirection.Input;


            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lRule = new List<WordRule>();
                    while (await dtr.ReadAsync())
                            {
                        
                            lRule.Add(new WordRule
                            {
                                PkSpeech = !dtr.IsDBNull(dtr.GetOrdinal("PK_Speech")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Speech")) : 0,
                                SpeechName = !dtr.IsDBNull(dtr.GetOrdinal("SpeechName")) ? dtr.GetString(dtr.GetOrdinal("SpeechName")) : "",
                                fk_Section = !dtr.IsDBNull(dtr.GetOrdinal("PK_Section")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Section")) : 0,
                                SectionName = !dtr.IsDBNull(dtr.GetOrdinal("SectionName")) ? dtr.GetString(dtr.GetOrdinal("SectionName")) : "",
                                PkRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_Rule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Rule")) : 0,
                                PkWorldRule = !dtr.IsDBNull(dtr.GetOrdinal("PK_WordRule")) ? dtr.GetInt32(dtr.GetOrdinal("PK_WordRule")) : 0,
                                Word = !dtr.IsDBNull(dtr.GetOrdinal("word")) ? dtr.GetString(dtr.GetOrdinal("word")) : "",
                                Weight = !dtr.IsDBNull(dtr.GetOrdinal("weight")) ? dtr.GetDecimal(dtr.GetOrdinal("weight")) : 0,
                                Sequence = !dtr.IsDBNull(dtr.GetOrdinal("sequence")) ? dtr.GetInt32(dtr.GetOrdinal("sequence")) : 0,
                                Status = true
                            });
                        }
                    }
                
            }
            return lRule;


        }
    }
}
