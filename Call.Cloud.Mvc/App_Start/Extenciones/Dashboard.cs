using Call.Cloud.Mvc.Models.DashBoard;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class Dashboard
    {
        //Gráfica Uno
        public async Task<IEnumerable<Elements>> grafica1(Elements Item)
        {
            List<Elements> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Dashboard_Grafica1",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Elements>();
                        while (await dr.ReadAsync())
                        {
                            Item = new Elements();
                            Item.PkAgent = dr["PK_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.result = Convert.ToInt32(dr["Result"].ToString());
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }

        //Gráfica Dos
        public async Task<IEnumerable<Elements>> grafica2(Elements Item)
        {
            List<Elements> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Dashboard_Grafica2",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Elements>();
                        while (await dr.ReadAsync())
                        {
                            Item = new Elements();
                            Item.nameBoss = dr["nameBoss"].ToString();
                            Item.QuantityAgent = Convert.ToInt32(dr["Cantidad_Agentes"].ToString());
                            Item.QuantityCall = Convert.ToInt32(dr["Cantidad_Llamadas"].ToString());
                            Item.nameBusiness = dr["name"].ToString();
                            Item.result = Convert.ToInt32(dr["result"]);                            
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }

        //Gráfica Tres
        public async Task<IEnumerable<Elements>> grafica3(Elements Item)
        {
            List<Elements> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Dashboard_Grafica3",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Elements>();
                        while (await dr.ReadAsync())
                        {
                            Item = new Elements();
                            Item.inicio = dr["Inicio"].ToString();
                            Item.fin = dr["Fin"].ToString();
                            Item.result = Convert.ToInt32(dr["Result"]);
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }

        //Gráfica Cuatro
        public async Task<IEnumerable<Elements>> grafica4(Elements Item)
        {
            List<Elements> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Dashboard_Grafica4",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<Elements>();
                        while (await dr.ReadAsync())
                        {
                            Item = new Elements();
                            Item.PkBusiness = dr["FK_Business"].ToString();
                            Item.result = Convert.ToInt32(dr["Result"]);
                            Item.nameBusiness = dr["name"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }
    }
}