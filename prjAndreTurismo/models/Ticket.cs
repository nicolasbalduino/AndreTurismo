using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime Checkin { get; set; }
        public Double Price { get; set; }
    }
}
