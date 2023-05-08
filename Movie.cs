using System;
using System.Collections.Generic;

namespace SuncoastMovies
{
    //This CLASS Movie has to match the Movie database from BEEKEEPER
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PrimaryDirector { get; set; }
        public int YearReleased { get; set; }
        public string Genre { get; set; }

        //This JOINS our Rating CLASS into our Movie CLASS
        //Added this to JOIN one to many from Rating CLASS so we can get back BEEKEEPER
        //Has to be the same name as the one from BEEKEEPER 
        public int RatingId { get; set; }
        //Added this so we can use Rating in Csharp 
        //What is says is the CLASS Rating is now a Property named Rating
        public Rating Rating { get; set; }


        //This JOINS our Role CLASS to the MOVIE class and is a MANY TO MANY 
        //BUt we First we make a one to many relationship 
        public List<Role> Roles { get; set; }
    }
}