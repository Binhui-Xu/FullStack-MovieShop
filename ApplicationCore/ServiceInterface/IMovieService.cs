using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailResponseModel> GetMoiveDetails(int id);
        // Task<List<MovieCardResponseModel>> GetMoviesByGenre(int gid);
    }
}
