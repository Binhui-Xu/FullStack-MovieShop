using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> Login(string email,string password);
        Task<UserPurchaseMovieResponseModel> PurchaseMovie(UserPurchaseMovieRequestModel model);
        Task<List<MovieCardResponseModel>> GetPurchasedMovies(int id);
        Task<UserDetailResponseModel> GetUserDetails(string email);
    }
}
