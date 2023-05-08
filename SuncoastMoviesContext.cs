using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SuncoastMovies
{
    //This class connects our CSHARP code to our BEEKEEPER Database

    public class SuncoastMoviesContext : DbContext
    {
        // DbSET<> is like a LIST and Acts Like a LIST 
        // Movie is a CLASS in cSHARP and Movies is from Beekeeper. Must be spelled the same as from BEEKEEPER
        // Telling our DB short for  DatabaseSET that our CLASS Movie is from BeeKeeper called Movies 
        public DbSet<Movie> Movies { get; set; }
        //We do the same for the Rating CLASS so it can be read by CSHARP
        public DbSet<Rating> Ratings { get; set; }
        //We do the same for the Role CLASS so it can be read in Csharp
        public DbSet<Role> Roles { get; set; }
        //Creating a DbSet<> for Class of Actor
        public DbSet<Actor> Actors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //This part of the code is IMPORTANT: we have to Type the CORRECT name of the DATABASE
            //Which is SuncoastMovies 
            //What this code below is doing is giving our cSharp the Information from our BEEKEEPER DATABASE 
            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");


            //THIS IS NOT MANDATORY****
            //THE code below allows the database to be SEEN in our CSHARP
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}