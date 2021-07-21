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
    public class ReviewRepository :EfRepository<Review>,IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Review>> ListAsync(Expression<Func<Review, bool>> filter)
        {
            var reviews = await _dbContext.Reviews.Where(filter).ToListAsync();
            return reviews;
        }
    }
}
