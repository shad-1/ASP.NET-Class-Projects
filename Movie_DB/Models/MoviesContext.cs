using System;
using Microsoft.EntityFrameworkCore;

namespace Movie_DB.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {
        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 1,
                    Title = "The Lord of the Rings: Fellowship of the Ring",
                    Year = 2001,
                    Category = Category.Action_Adventure,
                    Director = "Peter Jackson",
                    Rating = Rating.PG_13
                },
                new Movie
                {
                    MovieID = 2,
                    Title = "Batman: The Dark Knight",
                    Year = 2008,
                    Category = Category.Action_Adventure,
                    Director = "Christopher Nolan",
                    Rating = Rating.PG_13
                },
                new Movie
                {
                    MovieID = 3,
                    Title = "How to Train Your Dragon",
                    Year = 2010,
                    Category = Category.Family,
                    Director = "Chris Sanders",
                    Rating = Rating.PG
                }
            );
            
        }
    }
}
