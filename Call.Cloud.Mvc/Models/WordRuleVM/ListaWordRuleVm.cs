using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.WordRuleVM
{
    public class ListaWordRuleVm
    {
        public WordRule Filtro { get; set; }
        public IEnumerable<WordRule> Elementos { get; set; }
        

        public ListaWordRuleVm(WordRule filtro, IEnumerable<WordRule> listaword)
        {
            Filtro = filtro;
            Elementos = listaword;
            
        }
    }
}