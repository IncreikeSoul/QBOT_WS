using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Agent
    {
        public int PkAgent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PkBussines { get; set; }
        public string Dni { get; set; }
        public string CodInt { get; set; }
        public int Fk_Boss { get; set; }
        public string NameBussines { get; set; }
        public bool Flag_Fk_Boss { get; set; }
        public string Mail { get; set; }

        //public bool Flag_Fk_Boss
        //{
        //    get { return Fk_Boss == 0;}

        //    //set
        //    //{
        //    //    if (value)
        //    //        Fk_Boss = 0;
        //    //    else
        //    //        Fk_Boss = 1;
        //    //}
        //}
    }
}
