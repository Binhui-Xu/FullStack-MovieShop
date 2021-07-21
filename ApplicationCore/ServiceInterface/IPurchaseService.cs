using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IPurchaseService
    {
        Task<List<UserPurchaseMovieResponseModel>> GetAllPurchases();
        Task<UserPurchaseMovieResponseModel> PurchaseMovie(UserPurchaseMovieRequestModel model);
    }
}
