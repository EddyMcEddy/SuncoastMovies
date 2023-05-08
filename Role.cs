namespace SuncoastMovies
{
    public class Role
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }


        //This comes from our BEEKEEPER to have them JOIN 
        //Must be the same name as BEEKEEPER
        //These are the ForeignKeys or Id of each Actor/Movie
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        //TO FINALIZE the JOINING of CLASSES
        // WE USE THE CODE BELOW
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}