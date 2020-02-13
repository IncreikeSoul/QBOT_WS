using Call.Cloud.Mvc.Models.ReportsVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class Reporte
    {
        //graficas por empresa
        public async Task<IEnumerable<ReportsVm>> ejemplo(ReportsVm Item)
        {

            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Enterprise_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parm1 = cmd.Parameters.AddWithValue("@Enterpresi", Item.codigoEmpre ?? "");
                parm1.Direction = ParameterDirection.Input;


                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.año = dr["Year"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.name_enterprise = dr["name_Enterprise"].ToString();
                            Item.id_enterprise = dr["Enterprise"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }

        public async Task<IEnumerable<ReportsVm>> chart_google02(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            mostrar = new List<ReportsVm>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_Enterprise_Month";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parm1 = cmd.Parameters.AddWithValue("@Enterpresi", Item.codigoEmpre1 ?? "");
                    parm1.Direction = ParameterDirection.Input;
                    SqlParameter parm2 = cmd.Parameters.AddWithValue("@año", Item.añoPa1 ?? "");
                    parm2.Direction = ParameterDirection.Input;

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.fecha = dr["month"].ToString();
                                Item.cantidad1 = Convert.ToInt32(dr["Quantity"]);
                                Item.name = dr["name_Enterprise"].ToString();
                                Item.pk_enterprise = dr["Enterprise"].ToString();

                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportsVm>> Grafica_03(ReportsVm Item)
        {
            List<ReportsVm> Mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Enterprise_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@Entrepresi", Item.codigoEmpre2 ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Month", Item.ParaMes ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Year", Item.añoPa2 ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        Mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.cantidad2 = Convert.ToInt32(dr["Quantity"]);
                            Mostrar.Add(Item);
                        }
                    }
                }

                return Mostrar;
            }
        }

        public async Task<IEnumerable<ReportsVm>> ejemplo_pueva(ReportsVm Item)
        {

            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Enterprise_Year_prueva",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parm1 = cmd.Parameters.AddWithValue("@Enterpresi", Item.codigoEmpre ?? "");
                parm1.Direction = ParameterDirection.Input;


                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.año = dr["Year"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.name_enterprise = dr["name_Enterprise"].ToString();
                            Item.id_enterprise = dr["Enterprise"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }
        
        //graficas por oficina
        public async Task<IEnumerable<ReportVmOffice>> grafica01(ReportVmOffice Item)
        {
            List<ReportVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Office_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parma1 = cmd.Parameters.AddWithValue("@Enterpresi", Item.codigoEmpresa ?? "");
                parma1.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmOffice>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmOffice();
                            Item.añoofi = dr["Year"].ToString();
                            Item.cantidadoffice = Convert.ToInt32(dr["Quantity"]);
                            Item.pk_off = dr["Office"].ToString();
                            Item.name_office = dr["Name_office"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmOffice>> graficas002(ReportVmOffice Item)
        {
            List<ReportVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_Office_Month";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@office", Item.codigoOff ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añooff ?? "");
                    param2.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportVmOffice();
                                Item.mesof = dr["Month"].ToString();
                                Item.cantidadOfic = Convert.ToInt32(dr["Quantity"]);
                                Item.name = dr["Name_Office"].ToString();
                                Item.pk_office11 = dr["Office"].ToString();

                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmOffice>> grafica003(ReportVmOffice Item)
        {
            List<ReportVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_Office_Day";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@office", Item.pk_office ?? "");
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.YearPa ?? "");
                    SqlParameter param3 = cmd.Parameters.AddWithValue("@Month", Item.MonthPa ?? "");

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportVmOffice();
                                Item.MountDay = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                                Item.cantidadDay = Convert.ToInt32(dr["Quantity"]);
                                mostrar.Add(Item);

                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmOffice>> grafica01_Organizational(ReportVmOffice Item)
        {
            List<ReportVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Office_Year_Organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter parma1 = cmd.Parameters.AddWithValue("@Enterpresi", Item.codigoEmpresa ?? "");
                parma1.Direction = ParameterDirection.Input;

                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añoParametro ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {

                    if (dr != null)
                    {
                        mostrar = new List<ReportVmOffice>();

                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmOffice();
                            Item.añoofi = dr["Year"].ToString();
                            Item.cantidadoffice = Convert.ToInt32(dr["Quantity"]);
                            Item.pk_off = dr["Office"].ToString();
                            Item.name_office = dr["Name_office"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //grafica de subOffice

        public async Task<IEnumerable<ReportVmSubOffice>> grafica0001(ReportVmSubOffice Item)
        {
            List<ReportVmSubOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_SubOffice_Year";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@office", Item.parm_Pk_office ?? "");
                    param1.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmSubOffice>();
                            while (await dr.ReadAsync())
                            {

                                Item = new ReportVmSubOffice();
                                Item.año = dr["Year"].ToString();
                                Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                                Item.pk_subOffice = dr["SubOffice"].ToString();
                                Item.name_suboffice = dr["Name_suboffice"].ToString();
                                mostrar.Add(Item);
                            }
                        }
                    }

                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmSubOffice>> grafica0002(ReportVmSubOffice Item)
        {
            List<ReportVmSubOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                string proc = "Rsp_Report_SubOffice_Month";
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@subOffice", Item.pk_subOffice_Parm ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.YearPa ?? "");
                    param2.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmSubOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportVmSubOffice();
                                Item.mesSubOff = dr["Month"].ToString();
                                Item.cantidadsuboff = Convert.ToInt32(dr["Quantity"]);
                                Item.name = dr["Name_SubOffice"].ToString();
                                Item.pk_suboffice11 = dr["SubOffice"].ToString();
                                mostrar.Add(Item);
                            }
                        }
                    }
                    return mostrar;
                }

            }
        }

        public async Task<IEnumerable<ReportVmSubOffice>> grafica0003(ReportVmSubOffice Item)
        {
            List<ReportVmSubOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_SubOffice_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_subOffice", Item.pk_subOfficeDay ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añoDay ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Month", Item.mesDay ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmSubOffice>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmSubOffice();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.cantidadDay = Convert.ToInt32(dr["Quantity"]);
                            mostrar.Add(Item);
                        }
                    }

                }
                return mostrar;
            }


        }

        public async Task<IEnumerable<ReportVmSubOffice>> grafica0001_Organizational(ReportVmSubOffice Item)
        {
            List<ReportVmSubOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_SubOffice_Year_Organizational";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@office", Item.parm_Pk_office ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoParametros : "");
                    param2.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmSubOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportVmSubOffice();
                                Item.año = dr["Year"].ToString();
                                Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                                Item.pk_subOffice = dr["SubOffice"].ToString();
                                Item.name_suboffice = dr["Name_suboffice"].ToString();
                                mostrar.Add(Item);
                            }
                        }
                    }

                }
            }
            return mostrar;
        }
        //gracficas por negocio


        public async Task<IEnumerable<ReportVmBusiness>> graph_Year(ReportVmBusiness Item)
        {
            List<ReportVmBusiness> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Repart_Business_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pk_Business", Item.pk_Business_Parm ?? "");
                pamar1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBusiness>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBusiness();
                            Item.año = dr["Year"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.pk_Business = dr["Business"].ToString();
                            Item.name_business = dr["Name_business"].ToString();
                            mostrar.Add(Item);



                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReportVmBusiness>> graph_Month(ReportVmBusiness Item)
        {
            List<ReportVmBusiness> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Business_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@Pk_Business", Item.pk_Business_Par_month ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añoMonth ?? "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBusiness>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBusiness();
                            Item.mes = dr["Month"].ToString();
                            Item.cantidad1 = Convert.ToInt32(dr["Quantity"]);
                            Item.name_Bunisess01 = dr["Name_Business"].ToString();
                            Item.pk_business01 = dr["Business"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }


        public async Task<IEnumerable<ReportVmBusiness>> graph_Day(ReportVmBusiness Item)
        {
            List<ReportVmBusiness> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Business_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business", (Item != null) ? Item.pk_Business_Day_parm : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.Year_Param : "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Month", (Item != null) ? Item.Month_para : "");
                param3.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBusiness>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBusiness();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.cantidad3 = Convert.ToInt32(dr["Quantity"]);

                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }
        public async Task<IEnumerable<ReportVmBusiness>> graph_Business_Year_Organizational(ReportVmBusiness Item)
        {
            List<ReportVmBusiness> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Business_Year_Organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pk_Business", Item.pk_Business_Parm ?? "");
                pamar1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoParametro : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBusiness>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBusiness();
                            Item.año = dr["Year"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.pk_Business = dr["Business"].ToString();
                            Item.name_business = dr["Name_business"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }
            }
            return mostrar;
        }

        //Grafica por supervisor
        public async Task<IEnumerable<ReportVmBoss>> graph_Year_Boos(ReportVmBoss Item)
        {
            List<ReportVmBoss> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Boss_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_business", Item.pk_business ?? "");
                param1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBoss>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBoss();
                            Item.pk_Boss = dr["Boss"].ToString();
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.name_Boss = dr["Name_Boss"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReportVmBoss>> graph_month_Boss(ReportVmBoss Item)
        {
            List<ReportVmBoss> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Boss_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", (Item != null) ? Item.pk_Boss_Parm : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.Year_Parm : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBoss>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBoss();
                            Item.mes = dr["Month"].ToString();
                            Item.cantidad1 = Convert.ToInt32(dr["Quantity"]);
                            Item.pk_Boss01 = dr["Boss"].ToString();
                            Item.name_Boss01 = dr["Name_Boss"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReportVmBoss>> graph_Day_Boss(ReportVmBoss Item)
        {
            List<ReportVmBoss> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Boss_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", (Item != null) ? Item.pk_Boss_Parm1 : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Month", (Item != null) ? Item.month_Pam : "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.Year_Parm1 : "");
                param3.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBoss>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBoss();
                            Item.dia = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.cantidad2 = Convert.ToInt32(dr["Quantity"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }
        public async Task<IEnumerable<ReportVmBoss>> graph_Year_Boos_Organizational(ReportVmBoss Item)
        {
            List<ReportVmBoss> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Boss_Organizational_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_business", (Item != null) ? Item.pk_business : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoParametro : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmBoss>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmBoss();
                            Item.pk_Boss = dr["Boss"].ToString();
                            Item.año1 = dr["Year"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.name_Boss001 = dr["Name_Boss"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Grafica por Agente

        public async Task<IEnumerable<ReportVmAgent>> graph_Year_Agent(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pk_supervisor ?? "");
                param1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.codigo = dr["Agent"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.nombre_agente = dr["Name_Agent"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }



        public async Task<IEnumerable<ReportVmAgent>> graph_Month_Agent(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", (Item != null) ? Item.pk_agent : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.Year_Parm : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.mes = dr["Month"].ToString();
                            Item.cantidad1 = Convert.ToInt32(dr["Quantity"]);
                            Item.name_anget = dr["Name_Agent"].ToString();
                            Item.pk_agent01 = dr["Agent"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmAgent>> graph_Day_Agent(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", (Item != null) ? Item.pk_Boss_param : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@month", (Item != null) ? Item.Month_param : "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.YearParam : "");
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.cantidad2 = Convert.ToInt32(dr["Quantity"]);
                            Item.name_agentt = dr["name_Agent"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmAgent>> graph_Year_Agent_Organizational(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Organizational_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", (Item != null) ? Item.pk_supervisor : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoParametro : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.codigo = dr["Agent"].ToString();
                            Item.cantidad = Convert.ToInt32(dr["Quantity"]);
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.nombreAgent = dr["Name_Agent"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }
        //jhonatan fernandez



        public async Task<IEnumerable<ReportVmAgent>> Agent_LLamad(ReportVmAgent Item)
        {

            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Call",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_agente", (Item != null) ? Item.Para_pkagente : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@data", (Item != null) ? Convert.ToDateTime(Item.para_fecha).ToShortDateString() : "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {

                    if (dr != null)
                    {
                        mostrar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.cantidad000 = Convert.ToInt32(dr["Quantity"]);
                            Item.hora = dr["Hors"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

    }
}