using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;

namespace Infrastructure.Services
{
    public class GenreService :IGenreService<Genre>
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<List<GenreModel>> GetGenreList()
        {
            var genres =await _genreRepository.GetAllGenres();
            var genresList = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresList.Add(new GenreModel(){
                    Id=genre.Id,Name = genre.Name
                });
            }
            return genresList;
        }
    }
}