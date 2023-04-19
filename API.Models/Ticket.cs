using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime Checkin { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return  $"ID: {Id}" +
                    $"\nData de Check-In: {Checkin}" +
                    $"\nSaida: {Origin.City.Description}" +
                    $"\nChegada: {Destination.City.Description}" +
                    $"\nPassageiro: {Client.Name}" +
                    $"\nPreço da Passagem: {Price}\n";
        }
    }
}
