using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService  movieService,IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies == null)
            {
                return NotFound("No Movie");
            }
            return Ok(movies);
        }
        //attribute based routing, define our URL
        [HttpGet]
        [Route("toprevenue")] //will inheritant the class route
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }
            return Ok(movies); // Ok method from ControllerBase class
            //Json data HTTP Status Codes
            //two popular library:
            //1. NewtonSoft Json (popular for last ten years)
            //2. in .NET CORE 3.1 =>  SYtem.Text.Json(their own library)

        }
        //swagger request every action should have http action
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMoiveDetails(id);
            if (movie == null)
            {
                throw new Exception($"No Movie Found with {id}");
            }
            return Ok(movie);
        }
        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopTatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("No Movie Found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMovieByGenre(int id)
        {
            var genre = await _genreService.GetGenreDetails(id);
            if (genre == null)
            {
                return NotFound("No Genre");
            }
            var movies = new List<MovieCardResponseModel>();
            foreach (var movie in genre.Movies)
            {
                movies.Add(movie);
            }
            if (movies == null)
            {
                return NotFound("No Movie");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetMovieReviews(id);
            if (reviews == null)
            {
                return NotFound("No Reviews");
            }
            return Ok(reviews);
        }
        
    }
}