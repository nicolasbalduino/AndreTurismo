using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAndreTurismo.models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string CEP { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{Street}, Nº {Number} {Complement}, {Neighborhood}, {City}, {CEP}\n";
        }
    }
}
