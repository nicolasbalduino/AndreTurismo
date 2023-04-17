using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool CreateAddress(Address address) { return true; }

        public bool FindAll(Address address) { return true; }

        public bool UpdateAddress(Address address) { return true; }

        public bool DeleteAddress(Address address) { return true; }
    }
}
