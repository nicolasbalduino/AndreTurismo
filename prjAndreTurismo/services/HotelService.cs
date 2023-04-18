using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

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

        public int Insert(Hotel hotel)
        {
            string strInsert = "INSERT INTO Hotel (Name, IdAddress, Price) " +
                                "VALUES(@Name, @IdAddress, @Price);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", hotel.Address.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Price", hotel.Price));
            return (int)commandInsert.ExecuteScalar();
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
