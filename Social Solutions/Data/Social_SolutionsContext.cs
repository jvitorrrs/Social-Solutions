using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Social_Solutions.Models;

namespace Social_Solutions.Data
{
    public class Social_SolutionsContext : DbContext
    {
        public Social_SolutionsContext (DbContextOptions<Social_SolutionsContext> options)
            : base(options)
        {
        }

        public DbSet<Social_Solutions.Models.Clientes>? Clientes { get; set; }

        public DbSet<Social_Solutions.Models.Imoveis>? Imoveis { get; set; }
    }
}
