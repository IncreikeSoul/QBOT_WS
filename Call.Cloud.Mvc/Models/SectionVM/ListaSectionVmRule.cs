using Call.Cloud.Modelo;
using System.Collections.Generic;

namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class ListaSectionVmRule
    {
        public WordRule Filtro { get; set; }
        public IEnumerable<WordRule> Elementos { get; set; }
        public IEnumerable<Section> Reglas { get; set; }

        public ListaSectionVmRule(WordRule filtro, IEnumerable<WordRule> listaword, IEnumerable<Section> reglas)
        {
            Filtro = filtro;
            Elementos = listaword;
            Reglas = reglas;
        }

    }
}