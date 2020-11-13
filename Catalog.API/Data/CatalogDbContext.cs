using Catalog.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    /// <summary>
    /// https://code-maze.com/migrations-and-seed-data-efcore/#:~:text=%20Migrations%20and%20Seed%20Data%20with%20Entity%20Framework,as%20a%20result%20of%20that%2C%20we...%20More%20
    /// </summary>
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);

         
        }
    }
}
