using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime DtCreated { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
