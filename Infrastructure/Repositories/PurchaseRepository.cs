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
    public class PurchaseRepository:EfRepository<Purchase>,IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Purchase>> ListAsync(Expression<Func<Purchase, bool>> filter)
        {
            var purchases =await _dbContext.Purchases.Where(filter).ToListAsync();
            if (purchases ==null)
            {
                throw new Exception("No Purchase");
            }
            return purchases;
        }
    }
}