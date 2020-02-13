using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Call.Cloud.Mvc.Models.AudioVM
{
    public class Detalle_Audio
    {

        public  AudioVm Item { get; set; }
        
        public Detalle_Audio(AudioVm item)
        {
            Item = item;


        }
    }
}