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
    public class RuleLogica:GeneralLogica<Rule>
    {
        public override async Task<int> Edit(Rule Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                RuleDatos oRuleLogica = new RuleDatos();
                rpta=await oRuleLogica.Insert(cn, Item);                
            }
            return rpta;
        }

        public override async Task<Rule> Find(Rule Item)
        {
            Rule oRule = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                RuleDatos oRuleLogica = new RuleDatos();
                oRule = await oRuleLogica.Find(cn, Item);
            }
            return oRule;
        }

        public override async Task<IEnumerable<Rule>> Retrieve(Rule Item)
        {
            IEnumerable<Rule> lRule = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                RuleDatos oRuleLogica = new RuleDatos();
                lRule = await oRuleLogica.Retrieve(cn, Item);
            }
            return lRule;
        }
        //este no uso
        //public async Task<IEnumerable<Rule>> ListarWordRule(int rul)
        //{
        //    IEnumerable<Rule> lRule = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        RuleDatos ruledatos = new RuleDatos();
        //        lRule = await ruledatos.ListarWordRule(cn,rul);
        //    }

        //    return lRule;
        //}
        
        public override async Task<int> Delete(Rule Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                RuleDatos oRuleLogica = new RuleDatos();
                rpta = await oRuleLogica.Delete(cn, Item);
            }
            return rpta;
        }
    }
}
