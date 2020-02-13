using Call.Cloud.Mvc.Models.ReportVM01;
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
    public class Reporte01
    {
        //graficas por empresa
        public async Task<IEnumerable<ReportVmEnterpresi>> ejemplo(ReportVmEnterpresi Item)
        {

            List<ReportVmEnterpresi> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_whileListEnterpresi_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parm1 = cmd.Parameters.AddWithValue("@pk_enterpresi" ,Item.codigoEmpre ?? "");
                parm1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmEnterpresi>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmEnterpresi();
                            Item.año = dr["Year"].ToString();
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.portCumpli = Convert.ToInt32(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToInt32(dr["PorcenNotCump"]);
                            Item.Name_Enterprise = dr["name_Enterprise"].ToString();
                            Item.pk_Enterprise04 = dr["Enterprise"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }
        public async Task<IEnumerable<ReportVmEnterpresi>> ejemplo_ejemp(ReportVmEnterpresi Item)
        {

            List<ReportVmEnterpresi> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_whileListEnterpresi_Year_pr",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parm1 = cmd.Parameters.AddWithValue("@pk_enterpresi", (Item != null) ? Item.codigoEmpre : "");
                parm1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmEnterpresi>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmEnterpresi();
                            Item.año = dr["Year"].ToString();
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.portCumpli = Convert.ToInt32(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToInt32(dr["PorcenNotCump"]);
                            Item.Name_Enterprise = dr["name_Enterprise"].ToString();
                            Item.pk_enter = dr["Enterprise"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }


        public async Task<IEnumerable<ReportVmEnterpresi>> chart_google02(ReportVmEnterpresi Item)
        {
            List<ReportVmEnterpresi> mostrar = null;
            mostrar = new List<ReportVmEnterpresi>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_WhiteListEnterpresi_Month";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parm1 = cmd.Parameters.AddWithValue("@pk_enterpresi", Item.codigoEmpre1 ?? "");
                    parm1.Direction = ParameterDirection.Input;
                    SqlParameter parm2 = cmd.Parameters.AddWithValue("@Yaer", Item.añoPa1 ?? "");
                    parm2.Direction = ParameterDirection.Input;

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportVmEnterpresi>();
                            while (await dr.ReadAsync())
                            {

                                double complimi = Item.PortCumpl1;
                                Item = new ReportVmEnterpresi();
                                Item.fecha = dr["month"].ToString();
                                Item.PortCumpl1 = Convert.ToDouble(dr["PorcenCump"]);
                                Math.Round(complimi, 8);
                                Item.PortnoCumpl1 = Convert.ToDouble(dr["PorcenNotCump"]);
                                Item.cantCumpi1 = dr["CanCump"].ToString();
                                Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                                Item.name_Enterprise1 = dr["name_Enterprise"].ToString();
                                Item.pk_enterprise11 = dr["Enterprise"].ToString();
                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmEnterpresi>> Grafica_03(ReportVmEnterpresi Item)
        {
            List<ReportVmEnterpresi> Mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_WhiteListEnterprise_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_enterpresi", Item.codigoEmpre2 ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@month", Item.ParaMes ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Year", Item.añoPa2 ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        Mostrar = new List<ReportVmEnterpresi>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmEnterpresi();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.PortCumpl2 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi2 = dr["CanCump"].ToString();
                            Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                            Item.name_enterprise2 = dr["name_Enterprise"].ToString();
                            Mostrar.Add(Item);
                        }
                    }
                }

                return Mostrar;
            }
        }



        //graficas por oficina

        public async Task<IEnumerable<ReporVmOffice>> grafica01(ReporVmOffice Item)
        {
            List<ReporVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_WhiteListOffice_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parma1 = cmd.Parameters.AddWithValue("@pk_Enterpresi", Item.codigoEmpresa ?? "");
                parma1.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReporVmOffice>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReporVmOffice();
                            Item.añoofi = dr["Year"].ToString();
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.pk_off = dr["Office"].ToString();
                            Item.name_office = dr["name_Office"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReporVmOffice>> graficas002(ReporVmOffice Item)
        {
            List<ReporVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_WhiteList_Office_Month";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_office", Item.codigoOff ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añooff ?? "");
                    param2.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReporVmOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReporVmOffice();
                                Item.mesof = dr["Month"].ToString();
                                Item.portCumpli1 = Convert.ToDecimal(dr["PorcenCump"]);
                                Item.PortnoCumpl1 = Convert.ToDecimal(dr["PorcenNotCump"]);
                                Item.cantCumpi1 = dr["CanCump"].ToString();
                                Item.cantNocumpl = dr["CanNotCump"].ToString();
                                Item.name_office_month = dr["name_Office"].ToString();
                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReporVmOffice>> grafica003(ReporVmOffice Item)
        {
            List<ReporVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_WhiteList_Office_Day";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_office", (Item != null) ? Item.pk_office : "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Month", (Item != null) ? Item.MonthPa : "");
                    param2.Direction = ParameterDirection.Input;
                    SqlParameter param3 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.YearPa : "");
                    param3.Direction = ParameterDirection.Input;


                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReporVmOffice>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReporVmOffice();
                                Item.MountDay = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                                Item.portCumpli2 = Convert.ToDecimal(dr["PorcenCump"]);
                                Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                                Item.cantCumpi2 = dr["CanCump"].ToString();
                                Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                                Item.name = dr["name_Office"].ToString();
                                mostrar.Add(Item);

                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        public async Task<IEnumerable<ReporVmOffice>> grafica_office_Year_organi(ReporVmOffice Item)
        {
            List<ReporVmOffice> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_WhiteOffice_Year_Organizacional",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parma1 = cmd.Parameters.AddWithValue("@pk_Enterpresi", Item.codigoEmpresa ?? "");
                parma1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", (Item != null) ? Item.añoParametro : "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReporVmOffice>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReporVmOffice();
                            Item.añoofi = dr["Year"].ToString();
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.pk_off = dr["Office"].ToString();
                            Item.name_office_year = dr["name_Office"].ToString();
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
                string proc = "Rsp_WhiteList_SubOffice_Year";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_office", Item.parm_Pk_office ?? "");
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
                                Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                                Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                                Item.cantCumpi = dr["CanCump"].ToString();
                                Item.cantNocumpl = dr["CanNotCump"].ToString();
                                Item.pk_subOffice = dr["SubOffice"].ToString();
                                Item.name_subOffice = dr["name_SubOffice"].ToString();
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
                string proc = "Rsp_WhiteList_SubOffice_Month";
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_subOffice", Item.pk_subOffice_Parm ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.YearPa ?? "");
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
                                Item.portCumpli1 = Convert.ToDecimal(dr["PorcenCump"]);
                                Item.PortnoCumpl1 = Convert.ToDecimal(dr["PorcenNotCump"]);
                                Item.cantCumpi1 = dr["CanCump"].ToString();
                                Item.cantNocumpl1 = dr["CanNotCump"].ToString();
                                Item.name = dr["name_SubOffice"].ToString();
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
                    CommandText = "Rsp_WhiteList_SubOffice_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_subOffice", Item.pk_subOfficeDay ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@month", Item.mesDay ?? "");
                param3.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", Item.añoDay ?? "");
                param2.Direction = ParameterDirection.Input;


                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportVmSubOffice>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmSubOffice();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                            Item.portCumpli2 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi2 = dr["CanCump"].ToString();
                            Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                            Item.name_suboffice_day = dr["name_SubOffice"].ToString();
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
                string proc = "Rsp_WhileList_SubOffice_Yaer_Organizational";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_office", Item.parm_Pk_office ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@año", (Item != null) ? Item.añoParametro : "");
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
                                Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                                Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                                Item.cantCumpi = dr["CanCump"].ToString();
                                Item.cantNocumpl = dr["CanNotCump"].ToString();
                                Item.pk_subOffice = dr["SubOffice"].ToString();
                                Item.name_subOffice_Year = dr["name_SubOffice"].ToString();
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
                    CommandText = "Rsp_WhiteList_Bisiness_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pk_subOfice", Item.pk_Business_Parm ?? "");
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
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.pk_Business = dr["Business"].ToString();
                            Item.name_Business = dr["name_business"].ToString();
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
                    CommandText = "Rsp_WhiteList_Bisiness_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_business", Item.pk_Business_Par_month ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@year", Item.añoMonth ?? "");
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
                            Item.portCumpli1 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl1 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi1 = dr["CanCump"].ToString();
                            Item.cantNocumpl1 = dr["CanNotCump"].ToString();
                            Item.name = dr["name_business"].ToString();
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
                    CommandText = "Rsp_WhiteList_Bisiness_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_business", (Item != null) ? Item.pk_Business_Day_parm : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@year", (Item != null) ? Item.Year_Param : "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@month", (Item != null) ? Item.Month_para : "");
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
                            Item.portCumpli2 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi2 = dr["CanCump"].ToString();
                            Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                            Item.name_Business_Day = dr["name_business"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }


        public async Task<IEnumerable<ReportVmBusiness>> graph_Year_Business_Organizational(ReportVmBusiness Item)
        {
            List<ReportVmBusiness> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_WhiteList_Business_Year_Organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pk_subOfice", Item.pk_Business_Parm ?? "");
                pamar1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoPamaretro : "");
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
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.pk_Business = dr["Business"].ToString();
                            Item.name_Business_year = dr["name_business"].ToString();
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
                    CommandText = "Rsp_whiteList_Boss_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business", Item.pk_business ?? "");
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
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.name_boss = dr["name_boss"].ToString();
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
                    CommandText = "Rsp_whiteList_Boss_Month",
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
                            Item.portCumpli1 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl1 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi1 = dr["CanCump"].ToString();
                            Item.cantNocumpl1 = dr["CanNotCump"].ToString();
                            Item.name = dr["name_boss"].ToString();
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
                    CommandText = "Rsp_whiteList_Boss_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", (Item != null) ? Item.pk_Boss_Parm1 : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@month", (Item != null) ? Item.month_Pam : "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@Yaer", (Item != null) ? Item.Year_Parm1 : "");
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
                            Item.portCumpli2 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi2 = dr["CanCump"].ToString();
                            Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                            Item.name_boss_day = dr["name_boss"].ToString();
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
                    CommandText = "Rsp_WhiteList_Boss_Year_Organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business", (Item != null) ? Item.pk_business : "");
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
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.name_boss_year = dr["name_boss"].ToString();
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
                    CommandText = "Rsp_whiteList_Agent_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss",  Item.pk_supervisor ?? "");
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
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.name_agent = dr["name_Agent"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }
        public async Task<IEnumerable<ReportVmAgent>> graph_Year_Agent__Organizational(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_whiteList_Agent_Year_Organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", (Item != null) ? Item.pk_supervisor : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Year", (Item != null) ? Item.añoParametros : "");
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
                            Item.portCumpli = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi = dr["CanCump"].ToString();
                            Item.cantNocumpl = dr["CanNotCump"].ToString();
                            Item.año = Convert.ToInt32(dr["Year"]);
                            Item.nombreAgent = dr["name_Agent"].ToString();
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
                    CommandText = "Rsp_whiteList_Agent_Month",
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
                            Item.mes = dr["MONTH"].ToString();
                            Item.portCumpli1 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl1 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi1 = dr["CanCump"].ToString();
                            Item.cantNocumpl1 = dr["CanNotCump"].ToString();
                            Item.name = dr["name_Agent"].ToString();
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
                    CommandText = "Rsp_whiteList_Agent_Day",
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
                            Item.portCumpli2 = Convert.ToDecimal(dr["PorcenCump"]);
                            Item.PortnoCumpl2 = Convert.ToDecimal(dr["PorcenNotCump"]);
                            Item.cantCumpi2 = dr["CanCump"].ToString();
                            Item.cantNocumpl2 = dr["CanNotCump"].ToString();
                            Item.name_agent_day = dr["name_Agent"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        public async Task<IEnumerable<ReportVmAgent>> Grafica_llamada(ReportVmAgent Item)
        {
            List<ReportVmAgent> mostar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_whiteList_Call",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_agent", (Item != null) ? Item.Param_pk_Agente : "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@date", (Item != null) ? Convert.ToDateTime(Item.Param_Date).ToShortDateString() : "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostar = new List<ReportVmAgent>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportVmAgent();
                            Item.hora = dr["Hors"].ToString();
                            Item.CantCumpl0001 = Convert.ToInt32(dr["PorcenCump"]);
                            Item.cantNoCumpl0001 = Convert.ToInt32(dr["PorcenNotCump"]);
                            Item.name_agent_call = dr["name_Agent"].ToString();
                            mostar.Add(Item);

                        }
                    }
                }

            }
            return mostar;
        }



    }
}