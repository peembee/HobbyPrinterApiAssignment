using HobbyPrinterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HobbyPrinterApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Hobby> Hobbys { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
