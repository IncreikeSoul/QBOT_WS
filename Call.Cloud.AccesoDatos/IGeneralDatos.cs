using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public interface IGeneralDatos<T>
    {
        Task<int> Insert(SqlConnection Cn, T Item);
        Task<int> Update(SqlConnection Cn, T Item);
        Task<int> Delete(SqlConnection Cn, T Item);
        Task<IEnumerable<T>> Retrieve(SqlConnection Cn, T Item);
        Task<T> Find(SqlConnection Cn, T Item);
 
    }
}
