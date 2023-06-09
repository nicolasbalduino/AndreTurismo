﻿using System;
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

        public List<Ticket> FindAll()
        {
            string strSelect = 
                "SELECT t.Id, t.Checkin, t.Price, " +
                    "t.Origin, ao.Street aos, ao.Number aon, ao.Complement aoc, ao.Neighborhood aonb, " +
                        "co.Id coi, co.Description cod, ao.PostalCode aop," +
                    "t.Destination, ad.Street ads, ad.Number adn, ad.Complement adc, ad.Neighborhood adnb, " +
                        "cd.Id cdi, cd.Description cdd, ad.PostalCode adp," +
                    "t.ClientId, cl.Name cln" +
                " FROM Ticket t" +
                " JOIN Client cl ON t.ClientId = cl.Id" +
                " JOIN Address ao ON t.Origin = ao.Id" +
                " JOIN City co ON ao.IdCity = co.Id" +
                " JOIN Address ad ON t.Destination = ad.Id" +
                " JOIN City cd ON ad.IdCity = cd.Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            var results = commandSelect.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();

            while (results.Read()) 
            { 
                Ticket ticket = new Ticket();
                ticket.Id = (int)results["Id"];
                ticket.Price = (double)(decimal)results["Price"];
                ticket.Checkin = (DateTime)results["Checkin"];
                if (results["Origin"] != DBNull.Value)
                {
                    ticket.Origin = new();
                    ticket.Origin.Id = (int)results["Origin"];
                    ticket.Origin.Street = (string)results["aos"];
                    ticket.Origin.Number = (int)results["aon"];
                    ticket.Origin.Complement = (string)results["aoc"];
                    ticket.Origin.Neighborhood = (string)results["aonb"];
                    ticket.Origin.City = new();
                    ticket.Origin.City.Id = (int)results["coi"];
                    ticket.Origin.City.Description = (string)results["cod"];
                    ticket.Origin.CEP = (string)results["aop"];
                }
                if (results["Destination"] != DBNull.Value)
                {
                    ticket.Destination = new();
                    ticket.Destination.Id = (int)results["Destination"];
                    ticket.Destination.Street = (string)results["ads"];
                    ticket.Destination.Number = (int)results["adn"];
                    ticket.Destination.Complement = (string)results["adc"];
                    ticket.Destination.Neighborhood = (string)results["adnb"];
                    ticket.Destination.City = new();
                    ticket.Destination.City.Id = (int)results["cdi"];
                    ticket.Destination.City.Description = (string)results["cdd"];
                    ticket.Destination.CEP = (string)results["adp"];
                }
                if (results["ClientId"] != DBNull.Value)
                {
                    ticket.Client = new Client();
                    ticket.Client.Id = (int)results["ClientId"];
                    ticket.Client.Name = (string)results["cln"];
                }
                tickets.Add(ticket);
            }
            return tickets;
        }

        public Ticket FindById(int id)
        {
            string strSelect =
                "SELECT t.Id, t.Checkin, t.Price, " +
                    "t.Origin, ao.Street aos, ao.Number aon, ao.Complement aoc, ao.Neighborhood aonb, " +
                        "co.Id coi, co.Description cod, ao.PostalCode aop," +
                    "t.Destination, ad.Street ads, ad.Number adn, ad.Complement adc, ad.Neighborhood adnb, " +
                        "cd.Id cdi, cd.Description cdd, ad.PostalCode adp," +
                    "t.ClientId, cl.Name cln" +
                " FROM Ticket t" +
                " JOIN Client cl ON t.ClientId = cl.Id" +
                " JOIN Address ao ON t.Origin = ao.Id" +
                " JOIN City co ON ao.IdCity = co.Id" +
                " JOIN Address ad ON t.Destination = ad.Id" +
                " JOIN City cd ON ad.IdCity = cd.Id" +
                " WHERE t.Id = @Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            var results = commandSelect.ExecuteReader();

            Ticket ticket = new Ticket();
            if (results.Read())
            {
                ticket.Id = (int)results["Id"];
                ticket.Price = (double)(decimal)results["Price"];
                ticket.Checkin = (DateTime)results["Checkin"];
                if (results["Origin"] != DBNull.Value)
                {
                    ticket.Origin = new();
                    ticket.Origin.Id = (int)results["Origin"];
                    ticket.Origin.Street = (string)results["aos"];
                    ticket.Origin.Number = (int)results["aon"];
                    ticket.Origin.Complement = (string)results["aoc"];
                    ticket.Origin.Neighborhood = (string)results["aonb"];
                    ticket.Origin.City = new();
                    ticket.Origin.City.Id = (int)results["coi"];
                    ticket.Origin.City.Description = (string)results["cod"];
                    ticket.Origin.CEP = (string)results["aop"];
                }
                if (results["Destination"] != DBNull.Value)
                {
                    ticket.Destination = new();
                    ticket.Destination.Id = (int)results["Destination"];
                    ticket.Destination.Street = (string)results["ads"];
                    ticket.Destination.Number = (int)results["adn"];
                    ticket.Destination.Complement = (string)results["adc"];
                    ticket.Destination.Neighborhood = (string)results["adnb"];
                    ticket.Destination.City = new();
                    ticket.Destination.City.Id = (int)results["cdi"];
                    ticket.Destination.City.Description = (string)results["cdd"];
                    ticket.Destination.CEP = (string)results["adp"];
                }
                if (results["ClientId"] != DBNull.Value)
                {
                    ticket.Client = new Client();
                    ticket.Client.Id = (int)results["ClientId"];
                    ticket.Client.Name = (string)results["cln"];
                }
            }
            return ticket;
        }

        public bool Update(Ticket ticket) { return true; }

        public int Delete(int id)
        {
            string strDelete = "DELETE FROM Ticket WHERE Id = @Id";
            SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@Id", id));
            return commandDelete.ExecuteNonQuery();
        }
    }
}
