using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Call.Cloud.AccesoDatos;
using Call.Cloud.Modelo;
using System.Data.SqlClient;

namespace Call.Cloud.Logica
{
    public class EnterpriseLogica : GeneralLogica<Enterprise>
    {
        //public override async Task<IEnumerable<Enterprise>> Retrieve(Enterprise Item)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        EnterpriseDatos oSubOfficeDatos = new EnterpriseDatos();
        //        return await oSubOfficeDatos.Retrieve(cn, null);
        //    }
        //}

        public async Task<bool> EmpresaRegistrar(Enterprise objEnterpriseBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                EnterpriseDatos objEnterpriseDA = new EnterpriseDatos();
                return await objEnterpriseDA.EmpresaRegistrar(cn, objEnterpriseBE);
            }
        }

        public async Task<bool> EmpresaEliminar(Enterprise objEnterpriseBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                EnterpriseDatos objEnterpriseDA = new EnterpriseDatos();
                return await objEnterpriseDA.EmpresaEliminar(cn, objEnterpriseBE);
            }
        }

        public async Task<List<Enterprise>> EmpresaListar(Enterprise objEnterpriseBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                EnterpriseDatos objEnterpriseDA = new EnterpriseDatos();
                return await objEnterpriseDA.EmpresaListar(cn, objEnterpriseBE);
            }
        }

        //public List<Enterprise> Listar()
        //{
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        cn.Open();
        //        EnterpriseDatos oSubOfficeDatos = new EnterpriseDatos();
        //        return oSubOfficeDatos.Listar(cn);
        //    }
        //}

        public async Task<bool> GuardarFTP(EnterpriseFTPDatos objEnterpriseFTP)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                EnterpriseDatos oSubOfficeDatos = new EnterpriseDatos();
                return await oSubOfficeDatos.GuardarFTPAsync(cn, objEnterpriseFTP);
            }
        }

        public async Task<List<EnterpriseFTPDatos>> ListarFTP(EnterpriseFTPDatos objEnterpriseFTP)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion)) {
                await cn.OpenAsync();
                EnterpriseDatos objEnterpriseDatos = new EnterpriseDatos();
                return await objEnterpriseDatos.ListarFTP(cn, objEnterpriseFTP);
            }
        }

        public List<KeyValuePair<string, string>> EmpresaListarCombo()
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                cn.Open();
                EnterpriseDatos objEnterpriseDatos = new EnterpriseDatos();
                return objEnterpriseDatos.EmpresaListarCombo(cn);
            }
        }
    }
}
