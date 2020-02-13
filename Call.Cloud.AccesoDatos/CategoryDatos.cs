using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class CategoryDatos:IGeneralDatos<Category>
    {
        public Task<int> Insert(System.Data.SqlClient.SqlConnection Cn, Category Item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(System.Data.SqlClient.SqlConnection Cn, Category Item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(System.Data.SqlClient.SqlConnection Cn, Category Item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> Retrieve(System.Data.SqlClient.SqlConnection Cn, Category Item)
        {
            List<Category> lCategory = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspCategoryLst",
                CommandType=CommandType.StoredProcedure,
                Connection=Cn
            };
            SqlParameter param1 = cmd.Parameters.AddWithValue("@pName", (Item != null) ? Item.Name : "");
            param1.Direction = ParameterDirection.Input;

            using (SqlDataReader dtr=await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lCategory = new List<Category>();
                while (await dtr.ReadAsync())
                {
                    lCategory.Add(new Category()
                    {
                        PkCat = !dtr.IsDBNull(dtr.GetOrdinal("PK_Cat")) ? dtr.GetInt32(dtr.GetOrdinal("PK_Cat")) : 0,
                        Name = !dtr.IsDBNull(dtr.GetOrdinal("name")) ? dtr.GetString(dtr.GetOrdinal("name")) : ""
                    });
                }
            }
            return lCategory;
        }

        public Task<Category> Find(System.Data.SqlClient.SqlConnection Cn, Category Item)
        {
            throw new NotImplementedException();
        }
    }
}
