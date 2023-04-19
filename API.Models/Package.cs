using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Package
    {
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
