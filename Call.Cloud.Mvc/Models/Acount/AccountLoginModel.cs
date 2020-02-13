using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Call.Cloud.Mvc.Models.Acount
{
    public class AccountLoginModel
    {}

    public class LogOnModel
    {
        internal string pk_enterprise;

        public string pass { get; set; }
        public string user { get; set; }
        public string nombre_user { get; set; }
        public string parame_usuario { get; set; }
        public string parame_contra { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

}