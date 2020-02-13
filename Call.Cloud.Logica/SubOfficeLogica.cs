using Call.Cloud.AccesoDatos;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Logica
{
    public class SubOfficeLogica:GeneralLogica<SubOffice>
    {

        //public override async Task<IEnumerable<SubOffice>> Retrieve(SubOffice Item)
        //{
        //    IEnumerable<SubOffice> lSubOffice = null;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //        {
        //            await cn.OpenAsync();
        //            SubOfficeDatos oSubOfficeDatos = new SubOfficeDatos();
        //            lSubOffice = await oSubOfficeDatos.Retrieve(cn, Item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        lSubOffice = null;
        //        throw ex;
        //    }

        //    return lSubOffice;
        //}


        //public override async Task<int> Edit(SubOffice Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SubOfficeDatos oSubOfficeDatos = new SubOfficeDatos();
        //        rpta = await oSubOfficeDatos.Insert(cn, Item);
        //    }
        //    return rpta;
        //}

        //public override async Task<SubOffice> Find(SubOffice Item)
        //{
        //    SubOffice oSubOffice = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SubOfficeDatos oSubOfficeDatos = new SubOfficeDatos();
        //        oSubOffice = await oSubOfficeDatos.Find(cn, Item);
        //    }
        //    return oSubOffice;
        //}

        //public override async Task<int> Delete(SubOffice Item)
        //{

        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        SubOfficeDatos oSubOfficeDatos = new SubOfficeDatos();
        //        rpta = await oSubOfficeDatos.Delete(cn, Item);
        //    }
        //    return rpta;
        //}

        public async Task<bool> SubOficinaRegistrar(SubOffice objSubOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SubOfficeDatos objSubOfficeDA = new SubOfficeDatos();
                return await objSubOfficeDA.SubOficinaRegistrar(cn, objSubOfficeBE);
            }
        }

        public async Task<bool> SubOficinaEliminar(SubOffice objSubOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SubOfficeDatos objSubOfficeDA = new SubOfficeDatos();
                return await objSubOfficeDA.SubOficinaEliminar(cn, objSubOfficeBE);
            }
        }

        public async Task<List<SubOffice>> SubOficinaListar(SubOffice objSubOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SubOfficeDatos objSubOfficeDA = new SubOfficeDatos();
                return await objSubOfficeDA.SubOficinaListar(cn, objSubOfficeBE);
            }
        }

        public async Task<List<KeyValuePair<string, string>>> SubOficinaListarCombos(Office objOficinaBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                SubOfficeDatos objSubOfficeDA = new SubOfficeDatos();
                return await objSubOfficeDA.SubOficinaListarCombos(cn, objOficinaBE);
            }
        }
    }
}
