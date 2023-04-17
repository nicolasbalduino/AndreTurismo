using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime Created { get; set; }
    }
}
