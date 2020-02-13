using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Models.WhiteListVM
{
    public class busquedaYhimyVM
    {
        public WhiteList Item { get; set; }

        public busquedaYhimyVM(WhiteList item)
        {
            Item = item;
        }
    }
}