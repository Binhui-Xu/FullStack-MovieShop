using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieCardResponseModel> Movies { get; set; }
    }
}
