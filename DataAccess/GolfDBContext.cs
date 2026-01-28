using Microsoft.EntityFrameworkCore;
using MyProject_L00181476.Models;

namespace MyProject_L00181476.DataAccess
{
    public class GolfDBContext : DbContext
    {
        public GolfDBContext(DbContextOptions<GolfDBContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed top 5 golf brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, BrandName = "Titleist", Country = "USA", FoundedYear = 1932 },
                new Brand { Id = 2, BrandName = "Callaway", Country = "USA", FoundedYear = 1982 },
                new Brand { Id = 3, BrandName = "TaylorMade", Country = "USA", FoundedYear = 1979 },
                new Brand { Id = 4, BrandName = "Ping", Country = "USA", FoundedYear = 1959 },
                new Brand { Id = 5, BrandName = "Cobra", Country = "USA", FoundedYear = 1973 }
            );
        }
    }
}
