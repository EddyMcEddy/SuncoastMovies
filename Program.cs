using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuncoastMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            //ORM is what this SuncoastMovies is an Example of:
            //ORM is used when we have an outside database that we want to connect to our Csharp code


            //make our SuncoastMoviesContext into Context so we can use it in Program.cs
            var context = new SuncoastMoviesContext();

            //Creating a Movie Count which is counting how many movies are in our database has from our SuncoastMovies in BEEKEEPER
            var movieCount = context.Movies.Count();


            //Printing out How many Movies are in our SuncoastMovies from BEEKEEPER
            Console.WriteLine($"There are {movieCount} Movies");



            //This is JOINING our Rating CLASS to our Movie CLASS
            var moviesWithRatings = context.Movies.Include(movieCount => movieCount.Rating);

            //Loops thru each movie in Movies and shows us the Title of each and Rating since we Joined the Two CLASSES
            foreach (var movie in moviesWithRatings)
            {
                if (movie.Rating == null)
                {
                    Console.WriteLine($"The movie {movie.Title} with no rating ");
                }
                else
                {
                    Console.WriteLine($"These are the movie names {movie.Title} and there rating is {movie.Rating.Description} ");

                }

            }




            // Makes a new collection of movies but each movie knows the associated Rating object
            var moviesWithRatingsRolesAndActors = context.Movies.
                                                    // from our movie, please include the  Rating CLASS
                                                    Include(movie => movie.Rating).
                                                    // ... and from our movie, please include the Roles CLASS
                                                    Include(movie => movie.Roles).
                                                    // THEN for each of roles, please include the  Actor CLASS
                                                    ThenInclude(role => role.Actor);
            //Now we can loop Through the VARIABLE we made called moviesWithRatingsRolesAndActors
            foreach (var movie in moviesWithRatingsRolesAndActors)
            {
                if (movie.Rating == null)
                {
                    Console.WriteLine($"There is a movie named {movie.Title} and has not been rated yet");
                }
                else
                {
                    Console.WriteLine($"There is a movie named {movie.Title} and a rating of {movie.Rating.Description}");
                }
                foreach (var role in movie.Roles)
                {
                    Console.WriteLine($" - Has a character named {role.CharacterName} played by {role.Actor.FullName}");
                }
            }
            //This is ADDING  new Movie but thru Csharp instead of BEEKEEPER
            var newMovie = new Movie
            {
                Title = "SpaceBalls",
                PrimaryDirector = "Mel Brooks",
                Genre = "Comedy",
                YearReleased = 1987,
                RatingId = 2
            };
            //Adding it to our Movies
            context.Movies.Add(newMovie);
            context.SaveChanges();

            //This is UPDATING a movie 
            // Search for a movie by name. FirstOrDefault takes a function to use to compare the movies and returns the first record that matches, or if nothing matches, returns null.
            // This is the same as we used with LINQ against a List, but this time it is searching the database.
            var existingMovie = context.Movies.FirstOrDefault(movie => movie.Title == "SpaceBalls");

            // If we found an existing movie.
            if (existingMovie != null)
            {
                // Change the title of this movie.
                existingMovie.Title = "SpaceBalls - the best movie ever";

                // Ask the context to save changes.
                context.SaveChanges();
            }

            //This is DELETING a movie 
            var existingMovieToDelete = context.Movies.FirstOrDefault(movie => movie.Title == "Cujo");

            // If we found an existing movie.
            if (existingMovie != null)
            {
                // Remove the existing movie from the collection
                context.Movies.Remove(existingMovie);

                // Ask the context to save changes, in this case deleting the record.
                context.SaveChanges();
            }



        }
    }
}
