using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;

namespace Infrastructure.Services
{
    public class CastService:ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<MovieDetailResponseModel.CastResponseModel> GetCastDetails(int id)
        {
            var cast =await _castRepository.GetByIdAsync(id);
            var castDetails = new MovieDetailResponseModel.CastResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };
            
            castDetails.Movies = new List<MovieCardResponseModel>();
            foreach (var movie in cast.MovieCasts)
            {
                castDetails.Movies.Add(new MovieCardResponseModel()
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PostUrl = movie.Movie.PosterUrl,
                    Budget = movie.Movie.Budget.GetValueOrDefault()
                });
            }
            return castDetails;
        }
    }
}