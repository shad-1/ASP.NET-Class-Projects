using System;
using Microsoft.EntityFrameworkCore;
using Movie_DB.Enums;

namespace Movie_DB.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                }
                ) ;

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 1,
                    Title = "The Lord of the Rings: Fellowship of the Ring",
                    Year = 2001,
                    CategoryID = 1,
                    Director = "Peter Jackson",
                    Rating = Ratings.PG_13
                },
                new Movie
                {
                    MovieID = 2,
                    Title = "Batman: The Dark Knight",
                    Year = 2008,
                    CategoryID = 1,
                    Director = "Christopher Nolan",
                    Rating = Ratings.PG_13
                },
                new Movie
                {
                    MovieID = 3,
                    Title = "How to Train Your Dragon",
                    Year = 2010,
                    CategoryID = 4,
                    Director = "Chris Sanders",
                    Rating = Ratings.PG
                }
            );
            
        }
    }
}
