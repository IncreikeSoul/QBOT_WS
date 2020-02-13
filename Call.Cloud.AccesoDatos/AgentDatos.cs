using Call.Cloud.Modelo; // Proyecto Modelo
using System; //NotImplementedException
using System.Collections.Generic;
using System.Data;//SqlParameter
using System.Data.SqlClient;//SqlCommand
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class AgentDatos:IGeneralDatos<Agent>
    {

        public async Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentInsUp",
                CommandType=CommandType.StoredProcedure,
                Connection=Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Agent", Item.PkAgent);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pFirstName", Item.FirstName ?? "");
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pLastName", Item.LastName ?? "");
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@pPK_Bussines", Item.PkBussines);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@pDNI", Item.Dni ?? "");
            param5.Direction = ParameterDirection.Input;
            SqlParameter param6 = cmd.Parameters.AddWithValue("@pCodInt", Item.CodInt??"");
            param6.Direction = ParameterDirection.Input;
            SqlParameter param7 = cmd.Parameters.AddWithValue("@Fk_Boss", Item.Fk_Boss);
            param7.Direction = ParameterDirection.Input;
            SqlParameter param8 = cmd.Parameters.AddWithValue("@Flag_Fk_Boss", Item.Flag_Fk_Boss);
            param8.Direction = ParameterDirection.Input;
            SqlParameter param9 = cmd.Parameters.AddWithValue("@Mail", Item.Mail);
            param9.Direction = ParameterDirection.Input;
            SqlParameter param10 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param10.Direction = ParameterDirection.Output;

             rpta=await cmd.ExecuteNonQueryAsync();
            if (rpta > 0)
                return  cmd.Parameters["@pOutVal"].Value!=null?(int)cmd.Parameters["@pOutVal"].Value:-1;

            return rpta;
        }

        public async Task<int> Update(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentInsUp",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Agent", Item.PkAgent);
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pFirstName", Item.FirstName ?? "");
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pLastName", Item.LastName ?? "");
            param3.Direction = ParameterDirection.Input;
            SqlParameter param4 = cmd.Parameters.AddWithValue("@pPK_Business", Item.PkBussines);
            param4.Direction = ParameterDirection.Input;
            SqlParameter param5 = cmd.Parameters.AddWithValue("@pDNI", Item.Dni ?? "");
            param5.Direction = ParameterDirection.Input;
            SqlParameter param6 = cmd.Parameters.AddWithValue("@pCodInt", Item.CodInt ?? "");
            param6.Direction = ParameterDirection.Input;
            SqlParameter param7 = cmd.Parameters.AddWithValue("@pOutVal", 0);
            param7.Direction = ParameterDirection.Output;

            rpta = await cmd.ExecuteNonQueryAsync();
            if (rpta > 0)
                return cmd.Parameters["@pOutVal"].Value != null ? (int)cmd.Parameters["@pOutVal"].Value : -1;

            return rpta;

        }

        public async Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            int rpta = -1;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentDel",
                CommandType=CommandType.StoredProcedure,
                Connection=Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@ppPK_Agent", Item.PkAgent);
            param1.Direction = ParameterDirection.Input;
            rpta = await cmd.ExecuteNonQueryAsync();
            return rpta;
        }

        public async Task<IEnumerable<Agent>> RetrieveBoss(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstBossAudio",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Business", Item.PkBussines);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",                            
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0,
                            PkBussines = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }

        public async Task<IEnumerable<Agent>> RetrieveBossXAgent(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstBossAudioXAgent",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Business", Item.PkBussines);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0,
                            PkBussines = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }
        public async Task<IEnumerable<Agent>> GetElementsForBusiness(SqlConnection Cn, int pkbusiness)
        {            
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstBossAudio",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Business", pkbusiness);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0,
                            PkBussines = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }

        public async Task<Agent> listarSupervisores(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            Agent lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstBoss",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Business", Item.PkBussines);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new Agent();
                    while (await dtr.ReadAsync())
                    {
                        lAgent = (new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0,
                            PkBussines = !dtr.IsDBNull(dtr.GetOrdinal("PK_Business")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Business")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }

        //
        public async Task<IEnumerable<Agent>> RetrieveAgent(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstByAgent",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPkBoss", Item.Fk_Boss);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }

        public async Task<IEnumerable<Agent>> GetElementsForBoss(System.Data.SqlClient.SqlConnection Cn, int pkboss)
        {
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLstByAgent",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };

            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPkBoss", pkboss);
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0
                        });
                    }
                }

            }
            return lAgent;
        }

        public async Task<IEnumerable<Agent>> Retrieve(System.Data.SqlClient.SqlConnection Cn, Agent Item)
        {
            List<Agent> lAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentLst",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pFirstName", Item.FirstName??"");
            param1.Direction = ParameterDirection.Input;
            SqlParameter param2 = cmd.Parameters.AddWithValue("@pLastName", Item.LastName ?? "");
            param2.Direction = ParameterDirection.Input;
            SqlParameter param3 = cmd.Parameters.AddWithValue("@pPK_Bussines", Item.PkBussines);
            param3.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    lAgent = new List<Agent>();
                    while (await dtr.ReadAsync())
                    {
                        lAgent.Add(new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent"))?dtr.GetInt32(dtr.GetOrdinal("PK_Agent")):0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            LastName = !dtr.IsDBNull(dtr.GetOrdinal("lastName")) ? dtr.GetString(dtr.GetOrdinal("lastName")) : "",
                            NameBussines = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : "",
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : ""
                        });
                    }
                }
                
            }
            return lAgent;
        }


        public async Task<Agent> Find(SqlConnection Cn, Agent Item)
        {
            Agent oAgent = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspAgentById",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pPK_Agent", Item.PkAgent);
            param1.Direction = ParameterDirection.Input;     

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    oAgent = new Agent();
                    while (await dtr.ReadAsync())
                    {
                        oAgent = (new Agent
                        {
                            PkAgent = !dtr.IsDBNull(dtr.GetOrdinal("PK_Agent")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Agent")) : 0,
                            FirstName = !dtr.IsDBNull(dtr.GetOrdinal("firstNAme")) ? dtr.GetString(dtr.GetOrdinal("firstNAme")) : "",
                            LastName = !dtr.IsDBNull(dtr.GetOrdinal("lastName")) ? dtr.GetString(dtr.GetOrdinal("lastName")) : "",
                            PkBussines = !dtr.IsDBNull(dtr.GetOrdinal("Pk_Business")) ? dtr.GetInt32(dtr.GetOrdinal("Pk_Business")) : 0,
                            Dni = !dtr.IsDBNull(dtr.GetOrdinal("DNI")) ? dtr.GetString(dtr.GetOrdinal("DNI")) : "",
                            CodInt = !dtr.IsDBNull(dtr.GetOrdinal("CodInt")) ? dtr.GetString(dtr.GetOrdinal("CodInt")) : "",
                            Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("FK_Boss")) ? dtr.GetInt32(dtr.GetOrdinal("FK_Boss")) : 0,
                            Flag_Fk_Boss = !dtr.IsDBNull(dtr.GetOrdinal("Flag_Fk_Boss")) ? dtr.GetBoolean(dtr.GetOrdinal("Flag_Fk_Boss")) : false,
                            Mail = !dtr.IsDBNull(dtr.GetOrdinal("Mail")) ? dtr.GetString(dtr.GetOrdinal("Mail")) : ""
                        });
                    }
                }

            }
            return oAgent;
        }
    }
}
