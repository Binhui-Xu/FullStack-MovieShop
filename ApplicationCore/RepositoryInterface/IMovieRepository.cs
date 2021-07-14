using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterface
{
    public interface IMovieRepository :IAsyncRepository<Movie>
    {
        Task<List<Movie>> GetHighest30GrossingMovies();
    }
}
