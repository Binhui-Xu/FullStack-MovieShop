using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;

namespace Infrastructure.Services
{
    public class FaavoriteService :IFavoriteService
    {
        private IFavoriteRepository _favoriteRepository;
        private IMovieRepository _movieRepository;
        public FaavoriteService(IFavoriteRepository favoriteRepository, IMovieRepository movieRepository)
        {
            _favoriteRepository = favoriteRepository;
            _movieRepository = movieRepository;
        }
        public async Task<UserFavoriteResponseModel> AddFavoriteMovie(UserFavoriteRequestModel model)
        {
            var favorite = new Favorite
            {
                UserId = model.UserId,
                MovieId = model.MovieId
            };
            var addfavorite = await _favoriteRepository.AddAsync(favorite);
            var userfavorite = new UserFavoriteResponseModel
            {
                Id = addfavorite.Id,
                UserId = addfavorite.UserId,
                MovieId = addfavorite.MovieId
            };
            return userfavorite;
        }

        public async Task<List<MovieCardResponseModel>> GetFavoriteMovies(int id)
        {
            var favorites = await _favoriteRepository.ListAsync(f => f.UserId == id);
            var moviecard = new List<MovieCardResponseModel>();
            foreach (var purchase in favorites)
            {
                var favoritemovie = await _movieRepository.GetByIdAsync(purchase.MovieId);
                moviecard.Add(new MovieCardResponseModel()
                {
                    Id = favoritemovie.Id,
                    Title = favoritemovie.Title,
                    PostUrl = favoritemovie.PosterUrl,
                    Budget = favoritemovie.Budget.GetValueOrDefault()
                });

            }
            return moviecard;
        }
    }
}
