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
    }
}
