using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
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

        public int Insert(Package package)
        {
            string strInsert = "INSERT INTO Package (HotelId, TicketId, Price, ClientId) " +
                                "VALUES(@HotelId, @TicketId, @Price, @ClientId);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@HotelId", package.Hotel.Id));
            commandInsert.Parameters.Add(new SqlParameter("@TicketId", package.Ticket.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Price", package.Price));
            commandInsert.Parameters.Add(new SqlParameter("@ClientId", package.Client.Id));
            return (int)commandInsert.ExecuteScalar();
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
