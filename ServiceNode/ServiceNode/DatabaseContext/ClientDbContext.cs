using Microsoft.EntityFrameworkCore;
using ServiceNode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.DatabaseContext
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {

        }
    }
}
