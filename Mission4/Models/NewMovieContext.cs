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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovie>().HasData(
                new NewMovie
                {
                    MovieID = 1,
                    Category = "Comedy",
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
                    Category = "Family",
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
                    Category = "Action/Adventure",
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
