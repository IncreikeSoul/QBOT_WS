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
    public class WordRuleLogica:GeneralLogica<WordRule>
    {
        public async override Task<int> Edit(WordRule Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WordRuleDatos oWordRuleDatos = new WordRuleDatos();
                rpta = await oWordRuleDatos.Insert(cn, Item);
            }
            return rpta;
        }
        public async override Task<int> Delete(WordRule Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WordRuleDatos oWordRuleDatos = new WordRuleDatos();
                rpta = await oWordRuleDatos.Delete(cn, Item);
            }
            return rpta;
        }
        public async override Task<WordRule> Find(WordRule Item)
        {
            WordRule oWordRule =null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WordRuleDatos oWordRuleDatos = new WordRuleDatos();
                oWordRule = await oWordRuleDatos.Find(cn, Item);
            }
            return oWordRule;
        }
        public async override Task<IEnumerable<WordRule>> Retrieve(WordRule Item)
        {
            IEnumerable<WordRule> lWordRule = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WordRuleDatos oWordRuleDatos = new WordRuleDatos();
                lWordRule = await oWordRuleDatos.Retrieve(cn, Item);
            }
            return lWordRule;
        }

        public async Task<IEnumerable<WordRule>> ListarWordRule(int id)
        {
        
            IEnumerable<WordRule> lRule = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WordRuleDatos ruledatos = new WordRuleDatos();
                lRule = await ruledatos.ListarWordRule(cn, id);
            }

            return lRule;
        }

        /////////////////////////////////////////////////////////////////////////////
        //public async Task<IEnumerable<WordRule>> ListarWordRule1(int id)
        //{

        //    IEnumerable<WordRule> lRule = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        WordRuleDatos ruledatos = new WordRuleDatos();
        //        lRule = await ruledatos.ListarWordRule(cn, id);
        //    }

        //    //foreach(var wordRule in lRule) {
        //    //    var variable = new WordRule();
        //    //    int fk = wordRule.FkRule;
        //    //    if (fk == id) {
        //    //        variable.FkRule = wordRule.FkRule;
        //    //    }
        //    }
        //    return lRule;
        //}
        /////////////////////////////////////////////////////////////////////////////

        //public async Task<WordRule> ListarWordRule(WordRule Item)
        //{
        //    WordRule lRule = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        WordRuleDatos ruledatos = new WordRuleDatos();
        //        lRule = await ruledatos.ListarWordRule(cn, Item);
        //    }

        //    return lRule;
        //}

        
    }
}
