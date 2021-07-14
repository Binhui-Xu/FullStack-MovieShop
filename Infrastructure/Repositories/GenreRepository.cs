using System;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.data;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
