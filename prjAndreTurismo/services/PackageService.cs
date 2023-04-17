using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Package package)
        {
            return true;
        }

        public bool FindAll(Package package)
        {
            return true;
        }

        public bool UpdatePackage(Package package)
        {
            return true;
        }

        public bool DeletePackage(Package package)
        {
            return true;
        }
    }
}
