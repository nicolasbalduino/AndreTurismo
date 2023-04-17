using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool CreateHotel()
        {
            return true;
        }

        public bool FindAll()
        {
            return true;
        }

        public bool UpdateHotel()
        {
            return true;
        }

        public bool DeleteHotel()
        {
            return true;
        }
    }
}
