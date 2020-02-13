using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Alertas
{
    public class AlertaModel
    {
        public List<string> lsModel{ get; set; }
        public string NombreAlerta { get; set; }
        public int Id { get; set; }
        public int tiempo { get; set; }
    }
}