using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.Effectiveness;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Call.Cloud.Mvc.Models.AudioVM;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public class Reporte_Eficacia
    {
        //Empresa por Año
        public async Task<IEnumerable<ReportsVm>> ejemplo(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Repor_Effectiveness_Enterprise_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parm1 = cmd.Parameters.AddWithValue("@pk_enterprise", Item.pk_enterprise ?? "" );
                parm1.Direction = ParameterDirection.Input;


                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pk_enterprise = dr["PK_Enterprise"].ToString();
                            Item.name_enterprise = dr["nameEnterprise"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityOffice = !dr.IsDBNull(dr.GetOrdinal("QuantityOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantityOffice")) : -1; 
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
                return mostrar;
            }
        }

        //Empresa por Mes
        public async Task<IEnumerable<ReportsVm>> Chart_Month(ReportsVm Item)
        {
            List<ReportsVm> Mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessEnterprise_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkenterprise", Item.pk_enterprise ?? "" );
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "" );
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        Mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pk_enterprise = dr["PK_Enterprise"].ToString();
                            Item.name_enterprise = dr["nameEnterprise"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("results")) ? dr.GetDecimal(dr.GetOrdinal("results")) : -1;
                            Item.quantityOffice = !dr.IsDBNull(dr.GetOrdinal("QuantityOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantityOffice")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;                            
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            Mostrar.Add(Item);
                        }
                    }
                }

                return Mostrar;
            }
        }

        //Empresa por dia
        public async Task<IEnumerable<ReportsVm>> chart_Enterprise_Day(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_Effectiveness_Enterprise_MonthDay";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pkenterprise", Item.pk_enterprise ?? "");
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                    SqlParameter param3 = cmd.Parameters.AddWithValue("@mes", Item.month ?? "");

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.pk_enterprise = dr["PK_Enterprise"].ToString();
                                Item.name_enterprise = dr["nameEnterprise"].ToString();
                                Item.año = dr["Year"].ToString();
                                Item.month = dr["Month"].ToString();
                                Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                                Item.dateCreate = Convert.ToDateTime(dr["Datecreated"].ToString()).ToShortDateString();
                                Item.quantityOffice = !dr.IsDBNull(dr.GetOrdinal("QuantityOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantityOffice")) : -1;
                                Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                                Item.criterio = Convert.ToDecimal(dr["criterio"]);
                                mostrar.Add(Item);

                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        //Oficina Verticalmente
        public async Task<IEnumerable<ReportsVm>> chart_Office_Vertical(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            mostrar = new List<ReportsVm>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Repor_Effectiveness_Office_Vertical";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parm1 = cmd.Parameters.AddWithValue("@pkenterprise", Item.pk_enterprise ?? "");
                    parm1.Direction = ParameterDirection.Input;

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.pk_enterprise = dr["PK_Enterprise"].ToString();
                                Item.pk_office = dr["PK_Office"].ToString();
                                Item.name_office = dr["nameOffice"].ToString();
                                Item.año = dr["Year"].ToString();
                                Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                                Item.quantitySubOffice = !dr.IsDBNull(dr.GetOrdinal("QuantitySubOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantitySubOffice")) : -1;
                                Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                                Item.criterio = Convert.ToDecimal(dr["criterio"]);
                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        //Oficina por Año
        public async Task<IEnumerable<ReportsVm>> chart_Office(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            mostrar = new List<ReportsVm>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Repor_Effectiveness_Enterprise_Office";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parm1 = cmd.Parameters.AddWithValue("@pkenterprise", Item.pk_enterprise ?? "");
                    parm1.Direction = ParameterDirection.Input;
                    SqlParameter parm2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                    parm2.Direction = ParameterDirection.Input;

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.pk_enterprise = dr["PK_Enterprise"].ToString();
                                Item.pk_office = dr["PK_Office"].ToString();
                                Item.name_office = dr["nameOffice"].ToString();
                                Item.año = dr["Year"].ToString();
                                Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                                Item.quantitySubOffice = !dr.IsDBNull(dr.GetOrdinal("QuantitySubOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantitySubOffice")) : -1;
                                Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                                Item.criterio = Convert.ToDecimal(dr["criterio"]);
                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        //Oficina por Mes
        public async Task<IEnumerable<ReportsVm>> chartOfficeMonth(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessOfficeMonth",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter parma1 = cmd.Parameters.AddWithValue("@pkoffice", Item.pk_office ?? "");
                parma1.Direction = ParameterDirection.Input;
                SqlParameter parma2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                parma2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pk_office = dr["PK_Office"].ToString();
                            Item.name_office = dr["nameOffice"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("results")) ? dr.GetDecimal(dr.GetOrdinal("results")) : -1;
                            Item.quantitySubOffice = !dr.IsDBNull(dr.GetOrdinal("QuantitySubOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantitySubOffice")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Oficina por Dia
        public async Task<IEnumerable<ReportsVm>> chartOfficeDay(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                string proc = "Rsp_Report_Effectiveness_OfficeMonthDay";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pkoffice", Item.pk_office ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                    param2.Direction = ParameterDirection.Input;
                    SqlParameter param3 = cmd.Parameters.AddWithValue("@month", Item.month ?? "");
                    param3.Direction = ParameterDirection.Input;
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.PkReport = dr["PK_report"].ToString();
                                Item.pk_office = dr["PK_Office"].ToString();
                                Item.name_office = dr["nameOffice"].ToString();
                                Item.año = dr["Year"].ToString();
                                Item.month = dr["Month"].ToString();
                                Item.dias = Convert.ToDateTime(dr["Datecreated"].ToString()).ToShortDateString();
                                Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                                Item.quantitySubOffice = !dr.IsDBNull(dr.GetOrdinal("QuantitySubOffice")) ? dr.GetInt32(dr.GetOrdinal("QuantitySubOffice")) : -1;
                                Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                                Item.criterio = Convert.ToDecimal(dr["criterio"]);
                                mostrar.Add(Item);
                            }
                        }
                    }
                }
            }
            return mostrar;
        }

        //SubOficina Verticalmente
        public async Task<IEnumerable<ReportsVm>> Chart_SubOffice_Year_Vertical(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_SubOfficeYear_Vertical",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter parma1 = cmd.Parameters.AddWithValue("@pkoffice", Item.pk_office ?? "");
                parma1.Direction = ParameterDirection.Input;
                
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {

                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();

                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pk_office = dr["PK_Office"].ToString();
                            Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                            Item.nameSubOffice = dr["nameSubOffice"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBusiness = !dr.IsDBNull(dr.GetOrdinal("QuantityBusiness")) ? dr.GetInt32(dr.GetOrdinal("QuantityBusiness")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //SubOficina por Año
        public async Task<IEnumerable<ReportsVm>> Chart_SubOffice_Year(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_SubOfficeYear",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter parma1 = cmd.Parameters.AddWithValue("@pkoffice", Item.pk_office ?? "");
                parma1.Direction = ParameterDirection.Input;

                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {

                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();

                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pk_office = dr["PK_Office"].ToString();
                            Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                            Item.nameSubOffice = dr["nameSubOffice"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBusiness = !dr.IsDBNull(dr.GetOrdinal("QuantityBusiness")) ? dr.GetInt32(dr.GetOrdinal("QuantityBusiness")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Reporte por SubOficina por Mes
        public async Task<IEnumerable<ReportsVm>> Chart_SubOffice_Month(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                string proc = "Rsp_Report_EffectivenessSubOfficeMonth";
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = cmd.Parameters.AddWithValue("@pksubOffice", Item.pkSubOffice ?? "");
                    param1.Direction = ParameterDirection.Input;
                    SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                    param2.Direction = ParameterDirection.Input;

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            mostrar = new List<ReportsVm>();
                            while (await dr.ReadAsync())
                            {
                                Item = new ReportsVm();
                                Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                                Item.nameSubOffice = dr["nameSubOffice"].ToString();
                                Item.año = dr["Year"].ToString();
                                Item.month = dr["Month"].ToString();
                                Item.result = !dr.IsDBNull(dr.GetOrdinal("results")) ? dr.GetDecimal(dr.GetOrdinal("results")) : -1;
                                Item.quantityBusiness = !dr.IsDBNull(dr.GetOrdinal("QuantityBusiness")) ? dr.GetInt32(dr.GetOrdinal("QuantityBusiness")) : -1;
                                Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                                Item.criterio = Convert.ToDecimal(dr["criterio"]);
                                mostrar.Add(Item);
                            }
                        }
                    }
                    return mostrar;
                }

            }
        }

        //Reporte por SubOficina por Dia
        public async Task<IEnumerable<ReportsVm>> Chart_SubOffice_Day(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessSubOfficeMonthDay",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pksuboffice", Item.pkSubOffice ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@month", Item.month ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                            Item.nameSubOffice = dr["nameSubOffice"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.dias = Convert.ToDateTime(dr["Datecreated"].ToString()).ToShortDateString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBusiness = !dr.IsDBNull(dr.GetOrdinal("Quantitybusiness")) ? dr.GetInt32(dr.GetOrdinal("Quantitybusiness")) : -1; ;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }

                }
                return mostrar;
            }
        }

        //Business Verticalmente   
        public async Task<IEnumerable<ReportsVm>> Chart_Business_Year_Vertical(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBusinessYear_Vertical",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pksuboffice", Item.pkSubOffice ?? "");
                pamar1.Direction = ParameterDirection.Input;
                
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.nameBusiness = dr["nameBusiness"].ToString();
                            Item.pkSpeech = dr["PK_Speech"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBoss = !dr.IsDBNull(dr.GetOrdinal("QuantityBoss")) ? dr.GetInt32(dr.GetOrdinal("QuantityBoss")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Business por Año        
        public async Task<IEnumerable<ReportsVm>> Chart_Business_Year(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBusinessYear",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter pamar1 = cmd.Parameters.AddWithValue("@pksuboffice", Item.pkSubOffice ?? "");
                pamar1.Direction = ParameterDirection.Input;
                SqlParameter pamar2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                pamar2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkSubOffice = dr["PK_SubOffice"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.nameBusiness = dr["nameBusiness"].ToString();
                            Item.pkSpeech = dr["PK_Speech"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBoss = !dr.IsDBNull(dr.GetOrdinal("QuantityBoss")) ? dr.GetInt32(dr.GetOrdinal("QuantityBoss")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Business por Mes
        public async Task<IEnumerable<ReportsVm>> Chart_Business_Month(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBusinessMonth",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkbusiness", Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.nameBusiness = dr["nameBusiness"].ToString();
                            Item.pkSpeech = dr["PK_Speech"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("results")) ? dr.GetDecimal(dr.GetOrdinal("results")) : -1;
                            Item.quantityBoss = !dr.IsDBNull(dr.GetOrdinal("QuantityBoss")) ? dr.GetInt32(dr.GetOrdinal("QuantityBoss")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        //Business por Dia
        public async Task<IEnumerable<ReportsVm>> Chart_Business_Day(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBusinessMonthDay",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkbusiness", Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@mes",  Item.month ?? "");
                param3.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.nameBusiness = dr["nameBusiness"].ToString();
                            Item.pkSpeech = dr["PK_Speech"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.dias = Convert.ToDateTime(dr["Datecreated"].ToString()).ToShortDateString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityBoss = !dr.IsDBNull(dr.GetOrdinal("QuantityBoss")) ? dr.GetInt32(dr.GetOrdinal("QuantityBoss")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Supervisor Verticalmente
        public async Task<IEnumerable<ReportsVm>> Chart_Boss_Year_Vertical(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBossYear_Vertical",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkbusiness", Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameBoss"].ToString();
                            
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityAgent = !dr.IsDBNull(dr.GetOrdinal("QuantityAgent")) ? dr.GetInt32(dr.GetOrdinal("QuantityAgent")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Supervisor por Año
        public async Task<IEnumerable<ReportsVm>> Chart_Boss_Year(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBossYear",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkbusiness", Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameBoss"].ToString();                          
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityAgent = !dr.IsDBNull(dr.GetOrdinal("QuantityAgent")) ? dr.GetInt32(dr.GetOrdinal("QuantityAgent")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }
    
        //Supervisor por Mes
        public async Task<IEnumerable<ReportsVm>> Chart_Boss_Month(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessbossMonth",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkboss",  Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",Item.año ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameBoss"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("results")) ? dr.GetDecimal(dr.GetOrdinal("results")) : -1;
                            Item.quantityAgent = !dr.IsDBNull(dr.GetOrdinal("QuantityAgent")) ? dr.GetInt32(dr.GetOrdinal("QuantityAgent")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Supervisor por Dia
        public async Task<IEnumerable<ReportsVm>> Chart_Boss_Day(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessBossMonthDay",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkboss",  Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@mes",  Item.month ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameBoss"].ToString();                      
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.dias = Convert.ToDateTime(dr["Datecreated"].ToString()).ToShortDateString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("result")) ? dr.GetDecimal(dr.GetOrdinal("result")) : -1;
                            Item.quantityAgent = !dr.IsDBNull(dr.GetOrdinal("QuantityAgent")) ? dr.GetInt32(dr.GetOrdinal("QuantityAgent")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Agente Verticalmente
        public async Task<IEnumerable<ReportsVm>> Chart_Agent_Year_Vertical(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgentYear_Vertical",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkboss", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["Boss"].ToString();
                            Item.pkAgent = dr["PK_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("Results")) ? dr.GetDecimal(dr.GetOrdinal("Results")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        //Agente por Año
        public async Task<IEnumerable<ReportsVm>> Chart_Agent_Year(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgentYear",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkboss",  Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@pkBusiness", Item.pkBusiness ?? "");
                param3.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["Boss"].ToString();
                            Item.pkAgent = dr["PK_Agent"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();                    
                            Item.año = dr["Year"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("Results")) ? dr.GetDecimal(dr.GetOrdinal("Results")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        //Agente por Mes
        public async Task<IEnumerable<ReportsVm>> Chart_Agent_Month(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgentMonth",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkagent",  Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkAgent = dr["PK_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();                       
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["MONTH"].ToString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("Results")) ? dr.GetDecimal(dr.GetOrdinal("Results")) : -1;
                            //Item.quantity = Convert.ToInt32(dr["Quantity"]);
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        //Agente por Dia
        public async Task<IEnumerable<ReportsVm>> Chart_Agent_Day(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgentMonthday",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkagent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@mes", Item.month ?? "");

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkAgent = dr["PK_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.año = dr["Year"].ToString();
                            Item.month = dr["Month"].ToString();
                            Item.dias = Convert.ToDateTime(dr["DateCreated"].ToString()).ToShortDateString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("Result")) ? dr.GetDecimal(dr.GetOrdinal("Result")) : -1;
                            //Item.quantity = Convert.ToInt32(dr["Quantity"]);
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }
        
        //Llamada
        public async Task<IEnumerable<ReportsVm>> Agent_LLamada(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgentday_Call",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkagent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@dia", Convert.ToDateTime(Item.dias).ToShortDateString() ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    mostrar = new List<ReportsVm>();
                    if (dr != null)
                    {

                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();                                              
                            Item.pkAudio = dr["PK_Audio"].ToString();
                            Item.año = dr["Year"].ToString(); 
                            Item.dias = Convert.ToDateTime(dr["Datecreated"]).ToShortDateString();
                            Item.result = !dr.IsDBNull(dr.GetOrdinal("Results")) ? dr.GetDecimal(dr.GetOrdinal("Results")) : -1;
                            Item.hora = dr["hours"].ToString();
                            Item.criterio = Convert.ToDecimal(dr["criterio"]);
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Segmentado Boss
        //por año
        public async Task<IEnumerable<ReportsVm>> graph_Year_Boos(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Boss_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business", Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();

                        while (await dr.ReadAsync())
                        {
                            List<ReportsVm> nameBoss = new List<ReportsVm>();

                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameboss"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1;
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;

        }

        //Month
        public async Task<IEnumerable<ReportsVm>> graph_month_Boss(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Boss_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss ?? "" );
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "" );
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["pk_Boss"].ToString();
                            Item.nameBoss = dr["nameboss"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";

                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantity = !dr.IsDBNull(dr.GetOrdinal("Quantity")) ? dr.GetInt32(dr.GetOrdinal("Quantity")) : -1;
                            Item.month = dr["month"].ToString();
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //dia
        public async Task<IEnumerable<ReportsVm>> graph_Day_Boss(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Boss_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@month", Item.month ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@año", Item.año);
                param3.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.nameBoss = dr["nameBoss"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantity = !dr.IsDBNull(dr.GetOrdinal("Quantity")) ? dr.GetInt32(dr.GetOrdinal("Quantity")) : -1;
                            Item.dias = Convert.ToDateTime(dr["DateALTERd"]).ToShortDateString();
                            Item.month = dr["month"].ToString();
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //year organizational
        public async Task<IEnumerable<ReportsVm>> graph_Year_Boos_Organizational(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Boss_Year_Orgonizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business",  Item.pkBusiness ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBusiness = dr["PK_Business"].ToString();
                            Item.pkBoss = dr["pk_Boss"].ToString();
                            Item.nameBoss = dr["nameboss"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : 0;
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //Segmentado Agent
        //por año
        public async Task<IEnumerable<ReportsVm>> graph_Year_Agent(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgent_Year",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.pkAgent = dr["pk_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.name_secction1 = dr["nameSection01"].ToString();
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1; 
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }

        //month
        public async Task<IEnumerable<ReportsVm>> graph_Month_Agent(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Agent_Month",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent",  Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkAgent = dr["pk_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantity = !dr.IsDBNull(dr.GetOrdinal("Quantity")) ? dr.GetInt32(dr.GetOrdinal("Quantity")) : -1; 
                            Item.month = dr["month"].ToString();
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }

        //day
        public async Task<IEnumerable<ReportsVm>> graph_Day_Agent(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Agent_Day",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@month", Item.month ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkAgent = dr["pk_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";

                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantity = !dr.IsDBNull(dr.GetOrdinal("Quantity")) ? dr.GetInt32(dr.GetOrdinal("Quantity")) : -1; 
                            Item.dias = Convert.ToDateTime(dr["DateALTERd"]).ToShortDateString();
                            Item.month = dr["month"].ToString();
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }

        //year organizational
        public async Task<IEnumerable<ReportsVm>> graph_Year_Agent_Organizational(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_EffectivenessAgent_Year_organizational",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@year",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkBoss = dr["PK_Boss"].ToString();
                            Item.pkAgent = dr["pk_Agent"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.pkSection01 = dr["PK_Section01"].ToString();
                            Item.name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información";
                            Item.result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1;
                            Item.pkSection02 = dr["PK_Section02"].ToString();
                            Item.name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información";
                            Item.result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1;
                            Item.pkSection03 = dr["PK_Section03"].ToString();
                            Item.name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información";
                            Item.result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1;
                            Item.pkSection04 = dr["PK_Section04"].ToString();
                            Item.name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información";
                            Item.result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1;
                            Item.pkSection05 = dr["PK_Section05"].ToString();
                            Item.name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información";
                            Item.result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1;
                            Item.quantityCall = !dr.IsDBNull(dr.GetOrdinal("QuantityCall")) ? dr.GetInt32(dr.GetOrdinal("QuantityCall")) : -1; 
                            Item.año = dr["Year"].ToString();
                            mostrar.Add(Item);

                        }
                    }
                }

            }
            return mostrar;
        }

        //llamada
        public async Task<IEnumerable<ReportsVm>> Agent_LLamad(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;
            List<AudioVm> mostrar2 = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Effectiveness_Call_Agent",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@Datecreated", Convert.ToDateTime(Item.dias).ToShortDateString() ?? "");
                param2.Direction = ParameterDirection.Input;

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.Default))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();

                        while (await dr.ReadAsync())
                        {
                            mostrar.Add(new ReportsVm
                            {
                                pkAgent = dr["pk_Agent"].ToString(),
                                pkSpeech = dr["pkspeech"].ToString(),
                                pkSection01 = dr["PK_Section01"].ToString(),
                                name_secction1 = !dr.IsDBNull(dr.GetOrdinal("nameSection01")) ? dr.GetString(dr.GetOrdinal("nameSection01")) : "Sin Información",
                                result1 = !dr.IsDBNull(dr.GetOrdinal("results01")) ? dr.GetDecimal(dr.GetOrdinal("results01")) : -1,
                                pkSection02 = dr["PK_Section02"].ToString(),
                                name_secction2 = !dr.IsDBNull(dr.GetOrdinal("nameSection02")) ? dr.GetString(dr.GetOrdinal("nameSection02")) : "Sin Información",
                                result2 = !dr.IsDBNull(dr.GetOrdinal("results02")) ? dr.GetDecimal(dr.GetOrdinal("results02")) : -1,
                                pkSection03 = dr["PK_Section03"].ToString(),
                                name_secction3 = !dr.IsDBNull(dr.GetOrdinal("nameSection03")) ? dr.GetString(dr.GetOrdinal("nameSection03")) : "Sin Información",
                                result3 = !dr.IsDBNull(dr.GetOrdinal("results03")) ? dr.GetDecimal(dr.GetOrdinal("results03")) : -1,
                                pkSection04 = dr["PK_Section04"].ToString(),
                                name_secction4 = !dr.IsDBNull(dr.GetOrdinal("nameSection04")) ? dr.GetString(dr.GetOrdinal("nameSection04")) : "Sin Información",
                                result4 = !dr.IsDBNull(dr.GetOrdinal("results04")) ? dr.GetDecimal(dr.GetOrdinal("results04")) : -1,
                                pkSection05 = dr["PK_Section05"].ToString(),
                                name_secction5 = !dr.IsDBNull(dr.GetOrdinal("nameSection05")) ? dr.GetString(dr.GetOrdinal("nameSection05")) : "Sin Información",
                                result5 = !dr.IsDBNull(dr.GetOrdinal("results05")) ? dr.GetDecimal(dr.GetOrdinal("results05")) : -1,
                                dias = Convert.ToDateTime(dr["Datecreated"]).ToShortDateString(),
                                hora = dr["hora"].ToString(),
                                pkAudio = dr["pk_audio"].ToString()

                            });                            
                        }

                        if(await dr.NextResultAsync())
                        {
                            mostrar2 = new List<AudioVm>();
                            while (await dr.ReadAsync())
                            {
                                mostrar2.Add(new AudioVm
                                {                                   
                                    Pk_Agent = dr["PK_Agent"].ToString(),
                                    pkAudio = dr["PK_Audio"].ToString(),
                                    pkSection = dr["PK_Section"].ToString(),
                                    nameSection = dr["SectionName"].ToString(),
                                    dias = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString(),
                                    hora = dr["hours"].ToString(),
                                    pkRule = dr["PK_Rule"].ToString(),
                                    nameRule = dr["RuleName"].ToString(),
                                    start = !dr.IsDBNull(dr.GetOrdinal("startSecond")) ? dr.GetFloat(dr.GetOrdinal("startSecond")): 0,
                                    end = !dr.IsDBNull(dr.GetOrdinal("endSecond")) ? dr.GetFloat(dr.GetOrdinal("endSecond")): 0,
                                    direccionAudio = dr["PathMinThumbnails"].ToString(),
                                    fileName = dr["fileName"].ToString()
                                });
                            }
                        }
                    }
                    mostrar.ForEach(x =>
                        {
                            x.AudioRule = new List<AudioVm>();
                            mostrar2.ForEach(y =>
                                {
                                    if (x.pkAgent == y.Pk_Agent && x.dias == y.dias)
                                        x.AudioRule.Add(y);
                                });
                        });
                }
             
            }
            return mostrar;
        }


        //------------------------------------------Dinamico-----------------------------------------------
        //name_rule
        public async Task<IEnumerable<ReportsVm>> name_rule(ReportsVm Item)
        {
            List<ReportsVm> mostrar = null;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_name_section",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkaudio", Item.pkAudio ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@pk_section", Item.pkSection ?? "");
                param2.Direction = ParameterDirection.Input;
                
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkAudio = dr["PK_audio"].ToString();
                            Item.nameSection = dr["nameSection"].ToString();
                            Item.pk_Rule = dr["PK_Rule"].ToString();
                            Item.pkSection = dr["PK_Section"].ToString();
                            Item.name_rule = dr["nameRule"].ToString();
                            Item.starSecond = !dr.IsDBNull(dr.GetOrdinal("startSecond")) ? dr.GetFloat(dr.GetOrdinal("startSecond")) : 0;
                            Item.endSecond = !dr.IsDBNull(dr.GetOrdinal("endSecond")) ? dr.GetFloat(dr.GetOrdinal("endSecond")) : 0;
                            Item.state = Convert.ToInt32(dr["state"]);
                            Item.direccionAudio = dr["PathMinThumbnails"].ToString();
                            Item.fileName = dr["fileName"].ToString();
                            Item.nameAgent = dr["nameAgent"].ToString();
                            Item.PesoSeccion =  Convert.ToDouble(dr["PesoSeccion"].ToString());
                            Item.PesoRegla = Convert.ToDouble(dr["PesoRegla"].ToString());
                            Item.Cumplimiento = Convert.ToDouble(dr["Cumplimiento"].ToString());
                            Item.Total = Convert.ToDouble(dr["Total"].ToString());


                            mostrar.Add(Item);
                        }
                    }
                }

            }
            return mostrar;
        }
        //id_section
        public async Task<IEnumerable<ReportsVm>> id_sectio()
        {
            List<ReportsVm> mostrar = null;
            ReportsVm Item = null;
            using (SqlConnection cn= new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText= "Report_List_IDSection",
                    CommandType= CommandType.StoredProcedure,
                    Connection=cn
                };
                using (SqlDataReader dr= await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
                {
                    if (dr != null)
                    {
                        mostrar = new List<ReportsVm>();
                        while (await dr.ReadAsync())
                        {
                            Item = new ReportsVm();
                            Item.pkSection = dr["PK_Section"].ToString();
                            Item.name = dr["name"].ToString();
                            mostrar.Add(Item);
                        }
                    }
                }
            }
            return mostrar;
        }

        //segmentado dinamico supervisor
        //dinamico supervisor año
        public IEnumerable<SectionVm> obetner_name_columns01(ReportsVm Item)
        {
            var lista = new List<SectionVm>();

            DataTable t = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_prueba",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };


                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Business", Item.pkBusiness ?? "");
                SqlParameter param2 = cmd.Parameters.AddWithValue("@ano", Item.año);

                param1.Direction = ParameterDirection.Input;
                param2.Direction = ParameterDirection.Input;

                SqlDataAdapter dt = new SqlDataAdapter(cmd);

                dt.Fill(t);


                int count_column = t.Columns.Count;
                int count = t.Columns.Count;
                int count_row = t.Rows.Count;


                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int j = 0; j < t.Columns.Count; j++)
                    {

                        if (j > 1)
                        {

                            if (t.Columns[j].ColumnName != "pk_boss" && t.Columns[j].ColumnName != "Year")
                            {
                                lista.Add(new SectionVm
                                {
                                    Header = t.Columns[j].ColumnName,
                                    Value = t.Rows[i][j].ToString().Replace(",", "."),
                                    year = t.Rows[i][1].ToString(),
                                    pk_boss = t.Rows[i][0].ToString(),
                                    TotalColumn = t.Columns.Count - 2
                                });
                            }

                        }


                    }
                }


            }
            return lista;

        }

        // dinamico supervisor mes
        public IEnumerable<SectionVm> report_Boss_Month(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Boss_Month_dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_Business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año",  Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);

                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 4)
                        {



                            mostrar.Add(new SectionVm
                            {
                                Header = t.Columns[f].ColumnName,
                                Value = t.Rows[i][f].ToString().Replace(",", "."),
                                nameBoss = t.Rows[i][3].ToString(),
                                pk_boss = t.Rows[i][0].ToString(),
                                TotalColumn = t.Columns.Count - 5
                            });

                        }

                    }
                }

            }

            return mostrar;
        }

        //dinamico supervisor dia
        public IEnumerable<SectionVm> report_Boss_Day_dinamico(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Boss_Day_dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Boss", Item.pkBoss);
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@mes", Item.month ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@año", Item.año);
                param3.Direction = ParameterDirection.Input;

                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 5)
                        {
                            mostrar.Add(new SectionVm
                            {
                                Header = t.Columns[f].ColumnName,
                                Value = t.Rows[i][f].ToString(),

                                TotalColumn = t.Columns.Count - 6

                            });

                        }
                    }
                }
            }
            return mostrar;
        }
        
        //segmentado dinamico agente
        //dinamico agente año
        public IEnumerable<SectionVm> report_agent_year(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Year_Dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_Business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pkBoss", Item.pkBoss ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.añoPa ?? "");
                param2.Direction = ParameterDirection.Input;

                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 3)
                        {

                            mostrar.Add(new SectionVm
                            {

                                Header = t.Columns[f].ColumnName,
                                Value = t.Rows[i][f].ToString().Replace(",", "."),
                                pk_agent = t.Rows[i][1].ToString(),
                                year = t.Rows[i][3].ToString(),
                                TotalColumn = t.Columns.Count - 4
                            });
                        }
                    }

                }
            }
            return mostrar;
        }

        // dinamico agente mes
        public IEnumerable<SectionVm> report_agent_month(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Month_Dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 3)
                        {
                            if (t.Columns[f].ColumnName != "PK_Agent" && t.Columns[f].ColumnName != "Year")
                            {

                                mostrar.Add(new SectionVm
                                {
                                    Header = t.Columns[f].ColumnName,
                                    Value = t.Rows[i][f].ToString().Replace(",", "."),
                                    year = t.Rows[i][1].ToString(),
                                    pk_agent = t.Rows[i][0].ToString(),
                                    TotalColumn = t.Columns.Count - 4

                                });
                            }

                        }
                    }

                }
            }
            return mostrar;

        }

        //dinamico agente dia
        public IEnumerable<SectionVm> report_agent_day(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Day_Dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_agent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@mes", Item.month ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlParameter param3 = cmd.Parameters.AddWithValue("@año", Item.año ?? "");
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 4)
                        {
                            mostrar.Add(new SectionVm
                            {
                                Header = t.Columns[f].ColumnName,
                                Value = t.Rows[i][f].ToString(),
                                TotalColumn = t.Columns.Count - 5
                            });
                        }
                    }

                }
            }
            return mostrar;
        }

        //dinamico agente llamadas
        public IEnumerable<SectionVm> report_agent_call(ReportsVm Item)
        {
            var mostrar = new List<SectionVm>();
            DataTable t = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_Report_Agent_Call_Dinamico",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                SqlParameter param = cmd.Parameters.AddWithValue("@pk_business", Item.pkBusiness ?? "");
                param.Direction = ParameterDirection.Input;
                SqlParameter param1 = cmd.Parameters.AddWithValue("@pk_Agent", Item.pkAgent ?? "");
                param1.Direction = ParameterDirection.Input;
                SqlParameter param2 = cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(Item.dias).ToShortDateString() ?? "");
                param2.Direction = ParameterDirection.Input;
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(t);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    for (int f = 0; f < t.Columns.Count; f++)
                    {
                        if (f > 4)
                        {
                            mostrar.Add(new SectionVm
                            {
                                Header = t.Columns[f].ColumnName,
                                Value = t.Rows[i][f].ToString().Replace(",", "."),
                                pkAudio = t.Rows[i][1].ToString(),

                               
                            

                            

                                TotalColumn = t.Columns.Count - 5
                            });
                        }
                    }

                }
            }
            return mostrar;
        }
       
        public IEnumerable<ReportsVm> list_IDBusiness()
        {
            var mostrar = new List<ReportsVm>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Rsp_ListIDBusiness_Agent",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {

                    if (dr != null)
                    {
                        while (dr.Read())
                        {


                            mostrar.Add(new ReportsVm
                            {
                                pkBoss = dr["JefeID"].ToString(),
                                pkBusiness = dr["PK_Business"].ToString()
                            });

                        }
                    }
                }

            }
            return mostrar;

        }


    }
}