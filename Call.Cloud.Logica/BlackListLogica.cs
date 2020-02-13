using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Call.Cloud.Modelo;
using Call.Cloud.AccesoDatos;


namespace Call.Cloud.Logica
{
    public class BlackListLogica : GeneralLogica<BlackList>
    {
        public override async Task<int> Edit(BlackList Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BlackListDatos blackDatos = new BlackListDatos();
                rpta = await blackDatos.Insert(cn, Item);
            }
            return rpta;
        }

        public override async Task<int> Delete(BlackList Item)
        {
            int rpta = -1;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BlackListDatos blackDatos = new BlackListDatos();
                rpta = await blackDatos.Delete(cn, Item);
            }
            return rpta;
        }

        public override async Task<BlackList> Find(BlackList Item)
        {
            BlackList black = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BlackListDatos blackDatos = new BlackListDatos();
                black = await blackDatos.Find(cn, Item);
            }
            return black;
        }

        public override async Task<IEnumerable<BlackList>> Retrieve(BlackList Item)
        {
            IEnumerable<BlackList> black = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BlackListDatos blackDatos = new BlackListDatos();
                black = await blackDatos.Retrieve(cn, Item);
            }
            return black;
        }

        public async Task<IEnumerable<BlackList>> Buscar(BlackList Item)
        {
            IEnumerable<BlackList> blackLista = null;
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                BlackListDatos whitedatos = new BlackListDatos();
                blackLista = await whitedatos.Buscar(cn, Item);
            }
            return blackLista;
        }


    }
}
