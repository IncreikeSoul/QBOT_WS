using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.LoginVm
{
    public class Login_User
    {
        public string pass { get; set; }
        public string user { get; set; }
        public string nombre_user { get; set; }
        public string parame_usuario { get; set; }
        public string parame_contra { get; set; }
    }

    //public class LogOnModel
    //{
    //    [Required]
    //    [Display(Name = "User name")]
    //    public string UserName { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [Display(Name = "Remember me?")]
    //    public bool RememberMe { get; set; }
    //}

}