using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gnder { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }

        //Navigation
        public ICollection<MovieCrew> MovieCrews { get; set; }
    }
}