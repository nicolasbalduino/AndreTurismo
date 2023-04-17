using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool CreateClient(Client client)
        {
            return false;
        }

        public bool FindAll(Client client)
        {
            return false;
        }

        public bool UpdateClient(Client client)
        {
            return false;
        }

        public bool DeleteClient(Client client)
        {
            return false;
        }
    }
}
