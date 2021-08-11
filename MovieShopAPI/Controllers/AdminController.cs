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
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IPurchaseService _purchaseService;
        public AdminController(IUserService userService,IMovieService movieService,IPurchaseService purchaseService)
        {
            _userService = userService;
            _movieService = movieService;
            _purchaseService = purchaseService;
        }
        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> AddMoive([FromBody]MovieRequestModel model)
        {
            var movie = await _movieService.AddNewMovie(model);
            if (movie == null)
            {
                return NotFound("No Update");
            }
            return Ok(movie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie([FromBody]MovieDetailUpdateModel model)
        {
            var movie = await _movieService.UpdateMovieDetail(model);
            if(movie==null)
            {
                return NotFound("No Update");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("puchases")]
        public async Task<IActionResult> GetPurchases()
        {
            var purchases = await _purchaseService.GetAllPurchases();
            if (purchases == null)
            {
                return NotFound("No Purchase");
            }
            return Ok(purchases);
        }
    }
}