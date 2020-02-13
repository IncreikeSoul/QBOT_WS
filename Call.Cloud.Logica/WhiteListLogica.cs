using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Call.Cloud.Modelo;
using System.Data.SqlClient;
using Call.Cloud.AccesoDatos;

namespace Call.Cloud.Logica
{
    public class WhiteListLogica : GeneralLogica<WhiteList>
    {
        public async override Task<int> Edit(WhiteList Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WhiteListDatos whitedato = new WhiteListDatos();
                rpta = await whitedato.Insert(cn, Item);
            }

            return rpta;
        }

        public async override Task<int> Delete(WhiteList Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WhiteListDatos whitedato = new WhiteListDatos();
                rpta = await whitedato.Delete(cn, Item);
            }

            return rpta;
        }

        public async override Task<WhiteList> Find(WhiteList Item)
        {
            WhiteList white = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WhiteListDatos whitedato = new WhiteListDatos();
                white = await whitedato.Find(cn, Item);
            }
            return white;
        }

        public async override Task<IEnumerable<WhiteList>> Retrieve(WhiteList Item)
        {
            IEnumerable<WhiteList> whiteLista = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WhiteListDatos whitedatos = new WhiteListDatos();
                whiteLista = await whitedatos.Retrieve(cn, Item);
            }
            return whiteLista;
        }


        public async Task<IEnumerable<WhiteList>> Buscar(WhiteList Item)
        {
            IEnumerable<WhiteList> whiteLista = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                WhiteListDatos whitedatos = new WhiteListDatos();
                whiteLista = await whitedatos.Buscar(cn, Item);
            }
            return whiteLista;
        }

        public int BuscarYhimy(int id)
        {
           var whiteLista = -1 ;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                 cn.Open();
                WhiteListDatos whitedatos = new WhiteListDatos();
                whiteLista = whitedatos.BuscarYhimy(cn, id);
            }
            return whiteLista;
        }
    }
}
