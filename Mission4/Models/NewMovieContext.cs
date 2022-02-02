using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class NewMovieContext : DbContext
    {
        // constructor
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options)
        {
            // Stays blank currently
        }

        public DbSet<NewMovie> movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Action/Adventure"},
                new Category { CategoryID=2, CategoryName="Comedy"},
                new Category { CategoryID=3, CategoryName="Drama"},
                new Category { CategoryID=4, CategoryName="Family"},
                new Category { CategoryID=5, CategoryName="Horror/Suspense"},
                new Category { CategoryID=6, CategoryName="Miscellaneous"},
                new Category { CategoryID=7, CategoryName="Television"},
                new Category { CategoryID=8, CategoryName="VHS"}
                );
            mb.Entity<NewMovie>().HasData(
                new NewMovie
                {
                    MovieID = 1,
                    CategoryID = 2,
                    Title = "Crazy Rich Asians",
                    Year = 2018,
                    Director = "Jon M. Chu",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Best movie ever!!"
                },
                new NewMovie
                {
                    MovieID = 2,
                    CategoryID = 4,
                    Title = "The Princess and the Frog",
                    Year = 2009,
                    Director = "Ron Clements",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new NewMovie
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Spider-Man: No Way Home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                });
        }
    }
}
