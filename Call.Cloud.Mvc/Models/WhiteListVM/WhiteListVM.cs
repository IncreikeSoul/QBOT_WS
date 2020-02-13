using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.WhiteListVM
{
    public class WhiteListVM
    {
        public int pk_word { get; set; }
        
        public string word { get; set; }

        public decimal porcentaje { get; set; }

        public int PkenterPrise { get; set; }
        public string enterPrise { get; set; }
    }
}