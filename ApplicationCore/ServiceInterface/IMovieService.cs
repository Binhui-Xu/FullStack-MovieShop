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
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<UserReviewResponseModel>> GetMovieReviews(int id);
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<MovieDetailUpdateModel> UpdateMovieDetail(MovieDetailUpdateModel model);
        Task<MovieDetailUpdateModel> AddNewMovie(MovieRequestModel model);
    }
}
