using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IReviewService
    {
        Task<UserReviewResponseModel> AddMovieReview(UserReviewRequestModel model);
        Task<List<UserReviewResponseModel>> GetUserReviews(int id);
        Task<UserReviewResponseModel> UpdateUserReview(UserReviewRequestModel model);
    }
}
