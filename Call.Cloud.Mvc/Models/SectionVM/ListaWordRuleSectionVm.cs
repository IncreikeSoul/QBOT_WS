using AutoMapper;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class ListaWordRuleSectionVm
    {
        public IEnumerable<Section> Reglas { get; set; }
        public Rule FiltroRule { get; set; }
        public WordRule WordRuleLista { get; set; }
        public IEnumerable<Rule> WordRule { get; set; }
        public ListaWordRuleSectionVm(Rule filtrorule,WordRule filtrowordRule, IEnumerable<Section> reglas, IEnumerable<Rule> wordRule) //, IEnumerable<Section>elementos, IEnumerable<Rule> wordRule
        {
            FiltroRule = filtrorule;
            WordRuleLista = filtrowordRule;
            Reglas = reglas;
            WordRule = wordRule;
        }
    public WordRule Filtro { get; set; }
    public IEnumerable<WordRule> Elementos { get; set; }
        public IEnumerable<Section> worrule { get; set; }

        public ListaWordRuleSectionVm(WordRule filtro, IEnumerable<WordRule> worRule, IEnumerable<Section> reglas)
    {
        Filtro = filtro;
            Elementos = worRule;
            Reglas = reglas;
    }


}
}