using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.AgentVM
{
    public class AgentVm
    {

        public int PkAgent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PkBussines { get; set; }
        public string Dni { get; set; }
        public string CodInt { get; set; }
        public string Fk_Boss { get; set; }
        public string NameBussines { get; set; }
    }
}