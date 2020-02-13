using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaProcesamiento
{
    public class BE_TRANSCRIPCION
    {
        public string Texto { get; internal set; }

        public List<BE_PALABRA> lstPalabraBE { get; internal set; }
        public int IdNegocio { get; internal set; }
        public int IdSpeech { get; internal set; }
        public int IdAgente { get; internal set; }
        public int IdCall { get; internal set; }
        public string NumeroEntrada { get; internal set; }
        public string NombreArchivo { get; internal set; }
        public DateTime? FechaCreacion { get; internal set; }
        public string TamanoAudio { get; internal set; }
        public string RutaCompleta { get; internal set; }
        public int IdAudio { get; internal set; }
    }

    public class BE_PALABRA
    {
        internal string word;

        public int IdPalabra { get; internal set; }
        public string Texto { get; internal set; }
        public float Inicio { get; internal set; }
        public float Fin { get; internal set; }
        public int IdAudio { get; internal set; }
        public int PK_WordRule { get; internal set; }
        public int PK_Rule { get; internal set; }
        public int PK_audio { get; internal set; }
        public decimal NU_WeightSection { get; internal set; }
        public decimal NU_WeightRule { get; internal set; }
    }
}
