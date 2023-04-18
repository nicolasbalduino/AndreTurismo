using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.models
{
    public class Package
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public Double Price { get; set; }
        public Client Client { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return  $"ID: {Id}" +
                    $"\nHotel: {Hotel.Name}" +
                    $"\nPassagem: {Ticket.Id}" +
                    $"\nPreço: {Price}" +
                    $"\nCliente: {Client.Name}\n";
        }
    }
}
