using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            base.OnModelCreating(modeBuilder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
