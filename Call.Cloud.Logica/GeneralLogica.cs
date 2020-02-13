using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Logica
{
    public class GeneralLogica<T>
    {
        public string stringConexion { get; set; }
        public GeneralLogica()
        {
            stringConexion = ConfigurationManager.ConnectionStrings["CallCloud"].ConnectionString;
        }


        public virtual Task<int> Edit(T Item)
        {
            return null;
        }
        public virtual Task<IEnumerable<T>> Retrieve(T Item)
        {
            return null;
        }
        public virtual Task<T> Find(T Item)
        {
            return null;
        }
        public virtual Task<int> Delete(T Item)
        {
            return null;
        }        
    }
}
