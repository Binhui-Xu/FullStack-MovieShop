using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IGenreService
    {
        Task<List<GenreModel>> GetGenreList();
        Task<GenreModel> GetGenreDetails(int id);

    }
}