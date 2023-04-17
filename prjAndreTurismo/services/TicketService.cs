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

        public bool CreateTicket(Ticket ticket) { return true; }

        public bool FindAll(Ticket ticket) { return true; }

        public bool UpdateTicket(Ticket ticket) { return true; }

        public bool DeleteTicket(Ticket ticket) { return true; }
    }
}
