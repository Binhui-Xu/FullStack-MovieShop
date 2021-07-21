using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.data;

namespace Infrastructure.Repositories
{
    //inheritent 7 methods from EfRepository, and implement 1 from IMovieRepository
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id)
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating>0)
            {
                movie.Rating = movieRating;
            }

            return movie;
        }

        public async Task<List<Movie>> GetHighest30RatedMovies()
        {
            var toprating = await _dbContext.Movies.Include(m=>m.Reviews).OrderByDescending(m =>m.Rating).Take(30).ToListAsync();
            return toprating;
        }

    }
}
