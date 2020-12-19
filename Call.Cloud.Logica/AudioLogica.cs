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
    public class AudioLogica:GeneralLogica<AudioEva>
    {
        public async Task<List<AudioEva>> EvaluacionAudioListar(AudioEva objAudioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AudioDatos objAudioDA = new AudioDatos();
                return await objAudioDA.EvaluacionAudioListar(cn, objAudioBE);
            }
        }

        public async Task<List<Evaluacion>> EvaluacionSectionListar(Evaluacion objEvaluacionBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AudioDatos objAudioDA = new AudioDatos();
                return await objAudioDA.EvaluacionSectionListar(cn, objEvaluacionBE);
            }
        }

        public async Task<List<Evaluacion>> EvaluacionRulesListar(Evaluacion objEvaluacionBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AudioDatos objAudioDA = new AudioDatos();
                return await objAudioDA.EvaluacionRulesListar(cn, objEvaluacionBE);
            }
        }

        public async Task<List<Evaluacion>> EvaluacionDiccionarioListar()
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                AudioDatos objAudioDA = new AudioDatos();
                return await objAudioDA.EvaluacionDiccionarioListar(cn);
            }
        }
    }
}
