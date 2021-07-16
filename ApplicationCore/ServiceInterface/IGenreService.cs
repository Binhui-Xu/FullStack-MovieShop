using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IGenreService<T> where T:class
    {
        Task<List<GenreModel>> GetGenreList();
        
    }
}