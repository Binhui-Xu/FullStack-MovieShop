using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies =await _movieRepository.GetHighest30GrossingMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PostUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<MovieDetailResponseModel> GetMoiveDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetails = new MovieDetailResponseModel()
            {
                Id = movie.Id, Title = movie.Title, Budget = movie.Budget.GetValueOrDefault(),
                Rating=movie.Rating,Tagline = movie.Tagline,ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview,PosterUrl = movie.PosterUrl,RunTime = movie.RunTime,
                Revenue = movie.Revenue.GetValueOrDefault()
            };

            movieDetails.Casts = new List<MovieDetailResponseModel.CastResponseModel>();

            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new MovieDetailResponseModel.CastResponseModel
                {
                    Id = cast.CastID, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath
                });
            }

            movieDetails.Genres = new List<GenreModel>();
            foreach (var genre in movie.MovieGenres)
            {
                movieDetails.Genres.Add(new GenreModel
                    {
                        Id = genre.Genre.Id, Name = genre.Genre.Name
                    });
            }

            return movieDetails;

        }
    }
}
