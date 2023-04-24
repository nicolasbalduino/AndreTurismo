using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<API.Models.City> City { get; set; } = default!;

        public DbSet<API.Models.Address>? Address { get; set; }

        public DbSet<API.Models.Hotel>? Hotel { get; set; }

        public DbSet<API.Models.Client>? Client { get; set; }

        public DbSet<API.Models.Ticket>? Ticket { get; set; }

        public DbSet<API.Models.Package>? Package { get; set; }
    }
}
