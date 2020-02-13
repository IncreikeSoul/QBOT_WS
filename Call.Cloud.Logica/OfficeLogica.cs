using Call.Cloud.Modelo;
using System.Data.SqlClient;
using Call.Cloud.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Logica
{
    public class OfficeLogica : GeneralLogica<Office>
    {
        //public override async Task<int> Edit(Office Item)
        //{
        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        OfficeDatos oOfficeDatos = new OfficeDatos();
        //        rpta = await oOfficeDatos.Insert(cn, Item);
        //    }
        //    return rpta;
        //}


        //public override async Task<IEnumerable<Office>> Retrieve(Office Item)
        //{
        //    IEnumerable<Office> lOffice = null;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //        {
        //            await cn.OpenAsync();
        //            OfficeDatos oOfficeDatos = new OfficeDatos();
        //            lOffice = await oOfficeDatos.Retrieve(cn, Item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        lOffice = null;
        //        throw ex;
        //    }

        //    return lOffice;
        //}

        //public  async Task<IEnumerable<Office>> Read(Office Item)
        //{

        //    IEnumerable<Office> lOffice = null;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //        {
        //            await cn.OpenAsync();
        //            OfficeDatos oOfficeDatos = new OfficeDatos();
        //            lOffice = await oOfficeDatos.Read(cn, Item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        lOffice = null;
        //        throw ex;
        //    }

        //    return lOffice;
        //}

        //public override async Task<Office> Find(Office Item)
        //{
        //    Office oOffice = null;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        OfficeDatos oOfficeDatos = new OfficeDatos();
        //        oOffice = await oOfficeDatos.Find(cn, Item);
        //    }
        //    return oOffice;
        //}

        //public override async Task<int> Delete(Office Item)
        //{

        //    int rpta = -1;
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        OfficeDatos oOfficeDatos = new OfficeDatos();
        //        rpta = await oOfficeDatos.Delete(cn, Item);
        //    }
        //    return rpta;
        //}

        public async Task<bool> OficinaRegistrar(Office objOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                OfficeDatos objOfficeDA = new OfficeDatos();
                return await objOfficeDA.OficinaRegistrar(cn, objOfficeBE);
            }
        }

        public async Task<bool> OficinaEliminar(Office objOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                OfficeDatos objOfficeDA = new OfficeDatos();
                return await objOfficeDA.OficinaEliminar(cn, objOfficeBE);
            }
        }

        public async Task<List<Office>> OficinaListar(Office objOfficeBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                OfficeDatos objOfficeDA = new OfficeDatos();
                return await objOfficeDA.OficinaListar(cn, objOfficeBE);
            }
        }

        public async Task<List<KeyValuePair<string, string>>> OficinaListarCombos(Enterprise objEnterpriseBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                OfficeDatos objOfficeDA = new OfficeDatos();
                return await objOfficeDA.OficinaListarCombos(cn, objEnterpriseBE);
            }
        }
    }
}
