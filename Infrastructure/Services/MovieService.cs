using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IReviewRepository _reviewRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            
        }
        public MovieService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
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
                Revenue = movie.Revenue.GetValueOrDefault(), Price = movie.Price
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
        
        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetHighest30RatedMovies();
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

        public async Task<List<UserReviewResponseModel>> GetMovieReviews(int id)
        {
            var reviews = await _reviewRepository.ListAsync(r=>r.MovieId==id);
            var movieReviews = new List<UserReviewResponseModel>();
            foreach (var review in reviews)
            {
                movieReviews.Add(new UserReviewResponseModel
                {
                    MovieId=review.MovieId,
                    UserId=review.UserId,
                    Review=review.ReviewText,
                    Rating=review.Rating
                });
            }
            return movieReviews;
        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAllAsync();
            var movieList = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieList.Add(new MovieCardResponseModel
                {
                    Id=movie.Id,
                    Title=movie.Title,
                    PostUrl=movie.PosterUrl,
                    Budget=movie.Budget.GetValueOrDefault(),
                });
            }
            return movieList;
        }

        public async Task<MovieDetailUpdateModel> UpdateMovieDetail(MovieDetailUpdateModel model)
        {
            var movie = new Movie
            {
                Id = model.Id,
                Title=model.Title,
                PosterUrl=model.PosterUrl,
                BackdropUrl=model.BackdropUrl,
                Overview=model.Overview,
                Tagline=model.Tagline,
                Budget=model.Budget,
                Revenue=model.Revenue,
                ImdbUrl=model.ImdbUrl,
                TmdbUrl=model.TmdbUrl,
                ReleaseDate=model.ReleaseDate,
                RunTime=model.RunTime,
                Price=model.Price,
                OriginalLanguage=model.OriginalLanguage,
                CreatedDate=model.CreatedDate,
                UpdatedDate=model.UpdatedDate,
                UpdatedBy=model.UpdatedBy,
                CreatedBy=model.CreatedBy
            };
            var update = await _movieRepository.UpdateAsync(movie);
            var updatemovie = new MovieDetailUpdateModel
            {
                Id = update.Id,
                Title = update.Title,
                PosterUrl = update.PosterUrl,
                BackdropUrl = update.BackdropUrl,
                Overview = update.Overview,
                Tagline = update.Tagline,
                Budget = update.Budget,
                Revenue = update.Revenue,
                ImdbUrl = update.ImdbUrl,
                TmdbUrl = update.TmdbUrl,
                ReleaseDate = update.ReleaseDate,
                RunTime = update.RunTime,
                Price = update.Price,
                OriginalLanguage = update.OriginalLanguage,
                CreatedDate = update.CreatedDate,
                UpdatedDate = update.UpdatedDate,
                UpdatedBy = update.UpdatedBy,
                CreatedBy = update.CreatedBy
            };
            updatemovie.Genres = model.Genres;
            updatemovie.Casts = model.Casts;
            return updatemovie;
        }
        public async Task<MovieDetailUpdateModel> AddNewMovie(MovieRequestModel model)
        {
            var movie = new Movie
            {
                Title = model.Title,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Price = model.Price,
                OriginalLanguage = model.OriginalLanguage,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                UpdatedBy = model.UpdatedBy,
                CreatedBy = model.CreatedBy
            };
            var create = await _movieRepository.AddAsync(movie);
            var createmovie = new MovieDetailUpdateModel
            {
                Id = create.Id,
                Title = create.Title,
                PosterUrl = create.PosterUrl,
                BackdropUrl = create.BackdropUrl,
                Overview = create.Overview,
                Tagline = create.Tagline,
                Budget = create.Budget,
                Revenue = create.Revenue,
                ImdbUrl = create.ImdbUrl,
                TmdbUrl = create.TmdbUrl,
                ReleaseDate = create.ReleaseDate,
                RunTime = create.RunTime,
                Price = create.Price,
                OriginalLanguage = create.OriginalLanguage,
                CreatedDate = create.CreatedDate,
                UpdatedDate = create.UpdatedDate,
                UpdatedBy = create.UpdatedBy,
                CreatedBy = create.CreatedBy
            };
            createmovie.Genres = model.Genres;
            createmovie.Casts = model.Casts;
            return createmovie;
        }
    }
}
