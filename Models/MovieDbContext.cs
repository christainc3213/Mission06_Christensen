using Microsoft.EntityFrameworkCore;

namespace MovieCollectionApp.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) //constructor
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}