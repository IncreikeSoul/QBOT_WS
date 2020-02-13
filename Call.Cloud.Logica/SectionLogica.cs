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
    public class SectionLogica : GeneralLogica<Section>
    {
        //public async override Task<int> Edit(Section Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oSectionDatos = new SectionDatos();
        //        rpta = await oSectionDatos.Insert(cn, Item);
        //    }
        //    return rpta;
        //}
        //public async override Task<int> Delete(Section Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oSectionDatos = new SectionDatos();
        //        rpta = await oSectionDatos.Delete(cn, Item);
        //    }
        //    return rpta;
        //}
        //public async override Task<Section> Find(Section Item)
        //{
        //    Section oSection = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oSectionDatos = new SectionDatos();
        //        oSection = await oSectionDatos.Find(cn, Item);
        //    }
        //    return oSection;
        //}
        //public async override Task<IEnumerable<Section>> Retrieve(Section Item)
        //{
        //    IEnumerable<Section> lSection = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oSectionDatos = new SectionDatos();
        //        lSection = await oSectionDatos.Retrieve(cn, Item);
        //    }
        //    return lSection;
        //}
        
        //public async Task<IEnumerable<Section>> RetrieveSectionRuleWordRule(int id)
        //{
        //    IEnumerable<Section> lRule = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oRuleDatos = new SectionDatos();
        //        lRule = await oRuleDatos.RetrieveSectionRuleWordRule(cn, id);
        //    }
        //    return lRule;
        //}

        //public async Task<IEnumerable<Section>> RetrieveDrop(Section Item)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SectionDatos oCategoryDatos = new SectionDatos();
        //        return await oCategoryDatos.RetrieveDrop(cn, Item);
        //    }
        //}

        public async Task<bool> SeccionRegistrar(Section objSeccionBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SectionDatos objSectionDA = new SectionDatos();
                return await objSectionDA.SeccionRegistrar(cn, objSeccionBE);
            }
        }

        public async Task<bool> SeccionEliminar(Section objSeccionBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SectionDatos objSectionDA = new SectionDatos();
                return await objSectionDA.SeccionEliminar(cn, objSeccionBE);
            }
        }

        public async Task<List<Section>> SeccionListar(Section objSeccionBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SectionDatos objSectionDA = new SectionDatos();
                return await objSectionDA.SeccionListar(cn, objSeccionBE);
            }
        }

        public async Task<List<KeyValuePair<string, string>>> SectionListarCombos(Speech objSpeechBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SectionDatos objSectionDA = new SectionDatos();
                return await objSectionDA.SectionListarCombos(cn, objSpeechBE);
            }
        }
    }

}
