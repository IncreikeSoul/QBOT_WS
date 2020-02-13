using System.Collections.Generic;
using System.Threading.Tasks;
using Call.Cloud.AccesoDatos;
using Call.Cloud.Modelo;
using System.Data.SqlClient;
using System;

namespace Call.Cloud.Logica
{
    public class BusinessLogica : GeneralLogica<Business>
    {
        //public override async Task<IEnumerable<Business>> Retrieve(Business Item)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.stringConexion))
        //    {
        //        await cn.OpenAsync();
        //        BusinessDatos oSubOfficeDatos = new BusinessDatos();
        //        return await oSubOfficeDatos.Retrieve(cn, Item);
        //    }
        //}
        public async Task<IEnumerable<Business>> RetrieveActive(Business Item)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BusinessDatos oSubOfficeDatos = new BusinessDatos();
                return await oSubOfficeDatos.RetrieveActive(cn, null);
            }
        }

        public async Task<bool> NegocioRegistrar(Business objNegocioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BusinessDatos objBusinessDA = new BusinessDatos();
                return await objBusinessDA.NegocioRegistrar(cn, objNegocioBE);
            }
        }

        public async Task<bool> NegocioEliminar(Business objNegocioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BusinessDatos objBusinessDA = new BusinessDatos();
                return await objBusinessDA.NegocioEliminar(cn, objNegocioBE);
            }
        }

        public async Task<List<Business>> NegocioListar(Business objNegocioBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BusinessDatos objBusinessDA = new BusinessDatos();
                return await objBusinessDA.NegocioListar(cn, objNegocioBE);
            }
        }

        public Task<bool> SpeechRegistrar(Speech objSpeechBE)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KeyValuePair<string, string>>> NegocioListarCombos(SubOffice objSubOficinaBE)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BusinessDatos objBusinessDA = new BusinessDatos();
                return await objBusinessDA.NegocioListarCombos(cn, objSubOficinaBE);
            }
        }
    }
}
