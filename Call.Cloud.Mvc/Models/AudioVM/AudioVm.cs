using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.AudioVM
{
    public class AudioVm
    {
        public int pk_auido { get; set; }
        public string FirstName { get;set;}
        public string nameBusiness { get; set; }
        public int seconds { get; set; }
        public string dateCreated { get; set; }
        public string  date { get; set; }
        public string state { get; set; }
        public int PkAgent { get; set; }
        public int PK_Business { get; set; }
        public int Fk_Boss { get; set; }
        public string direccionAudio { get; set; }
        public string fileName { get; set; }
        public string filesize { get; set; }
        public string Placa { get; set; }

        //traendo las reglas 
        public string pkAudio { get; set; }
        public string Pk_Agent { get; set; }
        public string pkSection { get; set; }
        public string nameSection { get; set; }
        public string hora { get; set; }
        public string dias { get; set; }
        public string pkRule { get; set; }
        public string nameRule { get; set; }
        public float start { get; set; }
        public float end { get; set; }

        //detalle audio
        public string text { get; set; }
        public float starSecond { get; set; }
        public float endSecond { get; set; }
        public float duration { get; set; }

        
       


    }
}