using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IFavoriteService
    {
        Task<UserFavoriteResponseModel> AddFavoriteMovie(UserFavoriteRequestModel model);
        Task<List<MovieCardResponseModel>> GetFavoriteMovies(int id);
    }
}
