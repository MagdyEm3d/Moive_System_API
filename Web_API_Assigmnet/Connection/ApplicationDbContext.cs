using Microsoft.EntityFrameworkCore;
using Web_API_Assigmnet.Models;

namespace Web_API_Assigmnet.Connection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Moive> Moives { get; set; }
        public DbSet<Director> Directors { get; set; }  
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
