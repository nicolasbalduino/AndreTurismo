using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Package
    {
        public readonly static string INSERT = "INSERT INTO Package (HotelId, TicketId, Price, ClientId) VALUES(@HotelId, @TicketId, @Price, @ClientId);SELECT CAST(scope_identity() as INT);";
        public readonly static string SELECTALL = "SELECT p.Id, p.Price, c.Id, c.Name, h.Id, h.Name, t.Id, d.Id, cd.Id, cd.Description FROM Package p, Hotel h, Ticket t, Client c, Address d, City cd WHERE (p.HotelId = h.Id) and (p.TicketId = t.Id) and (p.ClientId = c.Id) and (t.Destination = d.Id) and (d.IdCity = cd.Id);";
        public readonly static string SELECTID =  "SELECT p.Id, p.Price, c.Id, c.Name, h.Id, h.Name, t.Id, d.Id, cd.Id, cd.Description FROM Package p, Hotel h, Ticket t, Client c, Address d, City cd WHERE (p.HotelId = h.Id) and (p.TicketId = t.Id) and (p.ClientId = c.Id) and (t.Destination = d.Id) and (d.IdCity = cd.Id) AND p.Id = @Id;";
        public readonly static string UPDATE = "UPDATE Package SET Price = @Price WHERE Id = @Id;";
        public readonly static string DELETE = "DELETE FROM Package WHERE Id = @Id;";
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public double Price { get; set; }
        public Client Client { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return  $"Pacote: {Id}" +
                    $"\nHotel: {Hotel.Name}" +
                    $"\nDestino: {Ticket.Destination.City}" +
                    $"\nPreço: {Price}" +
                    $"\nCliente: {Client.Name}\n";
        }
    }
}
