using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.Effectiveness;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Call.Cloud.Mvc.Models.Alertas;
using Call.Cloud.Mvc.Models.LoginVm;


namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class Alertas
    {
        public int NumeroAlertas()
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_NumeroAlerta",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {   
                        while (dr.Read())
                        {
                            rpta= !dr.IsDBNull(dr.GetOrdinal("NumAlertas")) ? dr.GetInt32(dr.GetOrdinal("NumAlertas")) : 0;
                        }
                    }
                }
            }
            return rpta;
        }

        public int NumeroNotificaciones()
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_NumNotificaciones",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            rpta = !dr.IsDBNull(dr.GetOrdinal("NumNotificaciones")) ? dr.GetInt32(dr.GetOrdinal("NumNotificaciones")) : 0;
                        }
                    }
                }
            }
            return rpta;
        }

        public List<Models.Alertas.AlertaModel> ListaAlertas()
        {
            List<Models.Alertas.AlertaModel> mostrar = null;
            Models.Alertas.AlertaModel Item = null;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_ListaAlertas",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Models.Alertas.AlertaModel>();
                        while (dr.Read())
                        {
                            Item = new Models.Alertas.AlertaModel();
                            Item.Id = Convert.ToInt32(dr["Id"].ToString());
                            Item.NombreAlerta = dr["word"].ToString();
                            Item.tiempo = Convert.ToInt32(dr["tiempo"].ToString());
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        public List<Models.Alertas.AlertaModel> ListaNotificaciones()
        {
            List<Models.Alertas.AlertaModel> mostrar = null;
            Models.Alertas.AlertaModel Item = null;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_ListarNotificaciones",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Models.Alertas.AlertaModel>();
                        while (dr.Read())
                        {
                            Item = new Models.Alertas.AlertaModel();
                            Item.Id = Convert.ToInt32(dr["Id"].ToString());
                            Item.NombreAlerta = dr["Tabla"].ToString();
                            Item.tiempo = Convert.ToInt32(dr["tiempo"].ToString());
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }



    }
}