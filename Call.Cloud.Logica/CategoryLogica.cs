using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Call.Cloud.AccesoDatos;
namespace Call.Cloud.Logica
{
    public class CategoryLogica:GeneralLogica<Category>
    {
        public override async Task<IEnumerable<Category>> Retrieve(Category Item)
        {
            using (SqlConnection cn = new SqlConnection(this.stringConexion))
            {
                await cn.OpenAsync();
                CategoryDatos oCategoryDatos = new CategoryDatos();
                return await oCategoryDatos.Retrieve(cn, Item);
            }
        }
    }
}
