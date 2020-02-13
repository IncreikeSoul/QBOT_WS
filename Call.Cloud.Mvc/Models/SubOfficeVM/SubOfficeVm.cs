using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.SubOfficeVM
{
    public class SubOfficeVm
    {
        public int PkSubOffice { get; set; }
        public string nameSubOffice { get; set; }
        public int PkOffice { get; set; }

        public string nameOffice { get; set; }
        public int PkEnterprise { get; set; }
    }
}