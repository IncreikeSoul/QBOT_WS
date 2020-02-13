using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.AccesoDatos
{
    public class EnterpriseFTPDatos
    {
        public int PK_ftp { get; set; }
        public int PK_Enterprise { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string Folder { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public string RutaCompleta {
            get {
                return Server + ": " + Port + "/" + Folder;
            }
        }
    }
}
