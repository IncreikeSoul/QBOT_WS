using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaProcesamiento
{
    public class BL_AUDIO
    {
        private DA_AUDIO objAudioDA = null;

        public BL_AUDIO() {
            objAudioDA = new DA_AUDIO();
        }

        internal bool registrarAudio(BE_TRANSCRIPCION objTranscripcionBE)
        {
            bool resultado = true;

            if (objAudioDA.registrarAudio(objTranscripcionBE))
            {
                if (objTranscripcionBE.lstPalabraBE.Count > 0) {
                    foreach (BE_PALABRA objPalabraBE in objTranscripcionBE.lstPalabraBE) {
                        objPalabraBE.IdAudio = objTranscripcionBE.IdAudio;
                        if (!objAudioDA.registrarPalabra(objPalabraBE)) {
                            resultado = false;
                            break;
                        }
                    }
                }
            }
            else {
                resultado = false;
            }

            return resultado;
        }

        internal BE_FTP obtenerDatosFtp(string codigo)
        {
            return objAudioDA.obtenerDatosFtp(codigo);
        }

        internal List<BE_PALABRA> obtenerPalabrasSpeech(string codigoSpeech)
        {
            return objAudioDA.obtenerPalabrasSpeech(codigoSpeech);
        }

        internal bool registrarPalabraDetalle(BE_PALABRA palabra)
        {
            return objAudioDA.registrarPalabraDetalle(palabra);
        }
    }
}
