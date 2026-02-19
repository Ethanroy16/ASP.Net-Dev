using MyProject_L00181476.Models.Models;
using MyProject_L00181476.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MyProject_L00181476.DataAccess
{
    public class GolfDBContext : DbContext
    {
        public GolfDBContext(DbContextOptions<GolfDBContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<GolfBall> GolfBalls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed top 5 golf brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, BrandName = "Titleist", Country = "USA", FoundedYear = 1932 },
                new Brand { Id = 2, BrandName = "Callaway", Country = "USA", FoundedYear = 1982 },
                new Brand { Id = 3, BrandName = "TaylorMade", Country = "USA", FoundedYear = 1979 },
                new Brand { Id = 4, BrandName = "Ping", Country = "USA", FoundedYear = 1959 },
                new Brand { Id = 5, BrandName = "Srixon", Country = "Japan", FoundedYear = 1996}
            );

            _ = modelBuilder.Entity<GolfBall>().HasData(
                new GolfBall
                {
                    Id = 1,
                    Name = "Pro V1",
                    Price = (float?)54.99,
                    Description = "Premium tour-level performance with soft feel and long distance.",
                    BrandId = 1
                },
                new GolfBall
                {
                    Id = 2,
                    Name = "TP5",
                    Price = (float?)52.99,
                    Description = "5-layer tour ball delivering speed and spin control.",
                    BrandId = 3
                },
                new GolfBall
                {
                    Id = 3,
                    Name = "Z-Star",
                    Price = (float?)49.99,
                    Description = "Tour performance ball with exceptional greenside spin.",
                    BrandId = 5
                },
                new GolfBall
                {
                    Id = 4,
                    Name = "Chrome Soft",
                    Price = (float?)50.99,
                    Description = "Soft feel with high ball speeds and excellent control.",
                    BrandId = 2
                }
            );
        }
    }
}
