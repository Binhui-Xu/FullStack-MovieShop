using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository :EfRepository<Cast>,ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Include(c => c.MovieCasts)
                .ThenInclude(c => c.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cast == null)
            {
                throw new Exception($"No Cast Found with {id}");
            }
            return cast;
        }
    }
}