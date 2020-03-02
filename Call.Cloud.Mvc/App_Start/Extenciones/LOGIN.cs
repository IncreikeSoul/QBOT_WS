using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.LoginVm;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Call.Cloud.Mvc.Models.Acount;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class LOGIN
    {
        public List<LogOnModel> Login_usuario(LogOnModel Item)

        {

            List<LogOnModel> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Login",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn,
                    CommandTimeout = 0
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@usuario", (Item != null) ? Item.parame_usuario : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@password", (Item != null) ? Item.parame_contra : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<LogOnModel>();
                        while (dr.Read())
                        {
                            Item = new LogOnModel();
                            Item.nombre_user = dr["name_user"].ToString();
                            Item.user = dr["usuario"].ToString();
                            Item.pass = dr["Password"].ToString();
                            Item.pk_enterprise = dr["pk_enterprise"].ToString();

                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }
    }
}