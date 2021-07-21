using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;

namespace Infrastructure.Services
{
    public class ReviewService :IReviewService
    {
        private IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<UserReviewResponseModel> AddMovieReview(UserReviewRequestModel model)
        {
            var review = new Review
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                ReviewText = model.Review,
                Rating = model.Rating
            };
            var addreview = await _reviewRepository.AddAsync(review);
            var userReview = new UserReviewResponseModel
            {
                MovieId = addreview.MovieId,
                UserId = addreview.UserId,
                Review = addreview.ReviewText,
                Rating = addreview.Rating
            };
            return userReview;
        }

        public async Task<List<UserReviewResponseModel>> GetUserReviews(int id)
        {
            var reviews = await _reviewRepository.ListAsync(r => r.UserId == id);
            var userReviews = new List<UserReviewResponseModel>();
            foreach (var review in reviews)
            {
                userReviews.Add(new UserReviewResponseModel
                {
                    MovieId = review.MovieId,
                    UserId = review.UserId,
                    Review = review.ReviewText,
                    Rating = review.Rating
                });
            }
            return userReviews;
        }

        public async Task<UserReviewResponseModel> UpdateUserReview(UserReviewRequestModel model)
        {
            var review = new Review
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                ReviewText = model.Review,
                Rating = model.Rating
            };
            var update = await _reviewRepository.UpdateAsync(review);
            var newReview = new UserReviewResponseModel
            {
                MovieId = update.MovieId,
                UserId = update.UserId,
                Review = update.ReviewText,
                Rating = update.Rating
            };
            return newReview;
        }
    }
}
