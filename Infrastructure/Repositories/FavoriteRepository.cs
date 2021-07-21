using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Favorite>> ListAsync(Expression<Func<Favorite, bool>> filter)
        {
            var favorites = await _dbContext.Favorites.Where(filter).ToListAsync();
            return favorites;
        }
    }
}
