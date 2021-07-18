using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;

namespace Infrastructure.Services
{
    public class GenreService :IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<List<GenreModel>> GetGenreList()
        {
            var genres =await _genreRepository.ListAllAsync();
            var genresList = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresList.Add(new GenreModel(){
                    Id=genre.Id,Name = genre.Name
                });
            }
            return genresList;
        }

        public async Task<GenreModel> GetGenreDetails(int id)
        {
            var genre =await _genreRepository.GetByIdAsync(id);
            var genreDetails = new GenreModel()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
            genreDetails.Movies = new List<MovieCardResponseModel>();
            foreach (var movie in genre.MovieGenres)
            {
                genreDetails.Movies.Add(new MovieCardResponseModel()
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PostUrl = movie.Movie.PosterUrl,
                    Budget = movie.Movie.Budget.GetValueOrDefault()
                });
            }
            return genreDetails;
        }
    }
}