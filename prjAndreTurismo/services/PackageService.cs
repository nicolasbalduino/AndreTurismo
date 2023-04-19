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

        public List<Package> FindAll()
        {
            List<Package> packages = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT p.Id, c.Name as client, cd.Description as destination, h.Name as hotel, p.Price");
            sb.Append(" FROM Package p, Hotel h, Ticket t, Client c, Address d, City cd");
            sb.Append(" WHERE (p.HotelId = h.Id) and (p.TicketId = t.Id) and (p.ClientId = c.Id) and (t.Destination = d.Id) and (d.IdCity = cd.Id)");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package showPackage = new();

                showPackage.Id = (int)dr["Id"];
                showPackage.Client = new()
                {
                    Name = (string)dr["client"],
                };
                showPackage.Ticket = new()
                {
                    Destination = new()
                    {
                        City = new()
                        {
                            Description = (string)dr["destination"],
                        }
                    }
                };
                showPackage.Hotel = new()
                {
                    Name = (string)dr["hotel"]
                };
                showPackage.Price = (double)(decimal)dr["Price"];

                packages.Add(showPackage);
            }
            return packages;
        }

        public Package FindById(int id)
        {
            string strSelect = "SELECT p.Id, c.Name as client, cd.Description as destination, h.Name as hotel, p.Price" +
                " FROM Package p, Hotel h, Ticket t, Client c, Address d, City cd" +
                " WHERE (p.HotelId = h.Id) and (p.TicketId = t.Id) and (p.ClientId = c.Id) and " +
                "(t.Destination = d.Id) and (d.IdCity = cd.Id) and (p.Id = @Id)";

            SqlCommand commandSelect = new(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = commandSelect.ExecuteReader();

            Package showPackage = new();
            if(dr.Read())
            {
                showPackage.Id = (int)dr["Id"];
                showPackage.Client = new()
                {
                    Name = (string)dr["client"],
                };
                showPackage.Ticket = new()
                {
                    Destination = new()
                    {
                        City = new()
                        {
                            Description = (string)dr["destination"],
                        }
                    }
                };
                showPackage.Hotel = new()
                {
                    Name = (string)dr["hotel"]
                };
                showPackage.Price = (double)(decimal)dr["Price"];
            }
            return showPackage;
        }

        public bool Update(Package package)
        {
            return true;
        }

        public bool Delete(Package package)
        {
            return true;
        }
    }
}
