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
    public class SpeechLogica:GeneralLogica<Speech>
    {
        //public async override Task<int> Edit(Speech Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        rpta = await oSpeechDatos.Insert(cn, Item);
        //    }
        //    return rpta;
        //}

        //public async override Task<int> Delete(Speech Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        rpta = await oSpeechDatos.Delete(cn, Item);
        //    }
        //    return rpta;
        //}

        //public async Task<List<ReporteDatos>> ListarAudioSpeech(Speech objSpeechBE)
        //{
        //    List<ReporteDatos> lstReporteBE = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        lstReporteBE = await oSpeechDatos.ListarAudioSpeechAsync(cn, objSpeechBE);
        //    }
        //    return lstReporteBE;
        //}

        //public async Task<List<ReporteDatos>> ListarAudioDetalle(AudioWts objAudio)
        //{
        //    List<ReporteDatos> lstReporteBE = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        lstReporteBE = await oSpeechDatos.ListarAudioDetalleAsync(cn, objAudio);
        //    }
        //    return lstReporteBE;
        //}

        //public async override Task<Speech> Find(Speech Item)
        //{
        //    Speech oSpeech = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        oSpeech = await oSpeechDatos.Find(cn, Item);
        //    }
        //    return oSpeech;
        //}

        //public async override Task<IEnumerable<Speech>> Retrieve(Speech Item)
        //{
        //    IEnumerable<Speech> lSpeech = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        lSpeech = await oSpeechDatos.Retrieve(cn, Item);
                
        //    }
        //    return lSpeech;
        //}

        //public async Task<IEnumerable<Speech>> RetrieveSectionSpeech(int id)
        //{
        //    IEnumerable<Speech> lSpeech = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oSpeechDatos = new SpeechDatos();
        //        lSpeech = await oSpeechDatos.RetrieveSectionSpeech(cn, id);
        //    }
        //    return lSpeech;
        //}

        public async Task<bool> SpeechRegistrar(Speech objSpeechBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SpeechDatos objSpeechDA = new SpeechDatos();
                return await objSpeechDA.SpeechRegistrar(cn, objSpeechBE);
            }
        }

        public async Task<List<KeyValuePair<string, string>>> SpeechListarCombos(Business objNegocioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SpeechDatos objSpeechDA = new SpeechDatos();
                return await objSpeechDA.SpeechListarCombos(cn, objNegocioBE);
            }
        }

        public async Task<bool> SpeechEliminar(Speech objSpeechBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SpeechDatos objSpeechDA = new SpeechDatos();
                return await objSpeechDA.SpeechEliminar(cn, objSpeechBE);
            }
        }

        public async Task<List<Speech>> SpeechListar(Speech objSpeechBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SpeechDatos objSpeechDA = new SpeechDatos();
                return await objSpeechDA.SpeechListar(cn, objSpeechBE);
            }
        }

        //public async Task<IEnumerable<Speech>> RetrieveRule(int id)
        //{
        //    IEnumerable<Speech> lsection = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SpeechDatos oRuleDatos = new SpeechDatos();

        //        lsection = await oRuleDatos.RetrieveRule(cn, id);

        //    }
        //    return lsection;
        //}
    }
}
