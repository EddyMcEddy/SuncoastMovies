using System.Collections.Generic;

namespace SuncoastMovies
{
    public class Rating
    {
        public int Id { get; set; }
        public string Description { get; set; }


        //Joining the Movie LIST into Rating 
        public List<Movie> Movies { get; set; }

    }
}