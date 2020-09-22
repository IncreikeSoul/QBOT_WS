using Call.Cloud.AccesoDatos;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Logica
{
    public class AgentLogica : GeneralLogica<Agent>
    {

        public override async Task<int> Edit(Agent Item)
        {
            int rpta = -1;            
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AgentDatos oAgentDatos = new AgentDatos();
                rpta = await oAgentDatos.Insert(cn,Item);
            }
            return rpta;
        }

        public override async Task<IEnumerable<Agent>> Retrieve(Agent Item)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }
            
            return lAgent;
        }

        public async Task<IEnumerable<Agent>> RetrieveBoss(Agent Item)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.RetrieveBoss(cn, Item);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }

            return lAgent;
        }
        public async Task<IEnumerable<Agent>> RetrieveBossXAgent(Agent Item)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.RetrieveBossXAgent(cn, Item);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }

            return lAgent;
        }

        public async Task<IEnumerable<Agent>> GetElementsForBusiness(int pkbusiness)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.GetElementsForBusiness(cn, pkbusiness);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }

            return lAgent;
        }

        public async Task<IEnumerable<Agent>> RetrievAgent(Agent Item)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.RetrieveAgent(cn, Item);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }

            return lAgent;
        }

        public async Task<IEnumerable<Agent>> GetElementsForBoss(int pkboss)
        {
            IEnumerable<Agent> lAgent = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(this.stringConexion))
                {
                    await cn.OpenAsync();
                    AgentDatos oAgentDatos = new AgentDatos();
                    lAgent = await oAgentDatos.GetElementsForBoss(cn, pkboss);
                }
            }
            catch (Exception ex)
            {

                lAgent = null;
                throw ex;
            }

            return lAgent;
        }

        public override async Task<Agent> Find(Agent Item)
        {
            Agent oAgent = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();                
                AgentDatos oAgentDatos = new AgentDatos();
                oAgent = await oAgentDatos.Find(cn, Item);
            }
            return oAgent;
        }

        public async Task<Agent> listarBoss(Agent Item)
        {
            Agent oAgent = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AgentDatos oAgentDatos = new AgentDatos();
                oAgent = await oAgentDatos.listarSupervisores(cn, Item);
            }
            return oAgent;
        }

        public override async Task<int> Delete(Agent Item)
        {

            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AgentDatos oAgentDatos = new AgentDatos();
                rpta = await oAgentDatos.Delete(cn, Item);
            }
            return rpta;
        }
        
        /*----------------------------------------------------------------------------------------------------------*/
        public async Task<List<KeyValuePair<string, string>>> AgentListarCombos(Business objNegocioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AgentDatos objAgentDA = new AgentDatos();
                return await objAgentDA.AgentListarCombos(cn, objNegocioBE);
            }
        }

    }
}
