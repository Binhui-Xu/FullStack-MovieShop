using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterface
{
    public interface IMovieRepository
    {
        List<Movie> GetHighest30GrossingMovies();
    }
}
