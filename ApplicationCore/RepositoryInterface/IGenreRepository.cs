using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterface
{
    public interface IGenreRepository :IAsyncRepository<Genre>
    {
        Task<List<Genre>> GetAllGenres();
    }
}
