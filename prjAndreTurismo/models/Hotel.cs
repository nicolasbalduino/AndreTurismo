using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public DateTime Created { get; set; }
        public Double Price { get; set; }
    }
}
