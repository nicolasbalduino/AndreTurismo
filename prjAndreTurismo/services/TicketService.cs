using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int Insert(Ticket ticket)
        {
            string strInsert = "INSERT INTO Ticket (Origin, Destination, ClientId, Checkin, Price) " +
                                "VALUES(@Origin, @Destination, @ClientId, @Checkin, @Price);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Origin", ticket.Origin.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Destination", ticket.Destination.Id));
            commandInsert.Parameters.Add(new SqlParameter("@ClientId", ticket.Client.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Checkin", ticket.Checkin));
            commandInsert.Parameters.Add(new SqlParameter("@Price", ticket.Price));
            return (int)commandInsert.ExecuteScalar();
        }

        public bool FindAll(Ticket ticket) { return true; }

        public bool UpdateTicket(Ticket ticket) { return true; }

        public bool DeleteTicket(Ticket ticket) { return true; }
    }
}
