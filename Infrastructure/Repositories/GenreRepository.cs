using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Genre> GetByIdAsync(int id)
        {
            var genre = await _dbContext.Genres.Include(g=>g.MovieGenres).ThenInclude(g=>g.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                throw new Exception($"No genre Found with {id}");
            }
            return genre;
        }

        public override async Task<IEnumerable<Genre>> ListAllAsync()
        {
            var genres = await _dbContext.Genres.Include(g => g.MovieGenres).ThenInclude(g => g.Movie).ToListAsync();
            return genres;
        }
    }
}
