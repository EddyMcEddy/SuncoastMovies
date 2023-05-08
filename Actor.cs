using System;
using System.Collections.Generic;

namespace SuncoastMovies
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }


        //JOINING Actor class to => Role class which then JOINS => Movies CLass
        public List<Role> Roles { get; set; }
    }
}