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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPurchaseService _purchaseService;
        private readonly IReviewService _reviewService;
        private readonly IFavoriteService _favoriteService;
        public UserController(IUserService userService,
            IPurchaseService purchaseService,
            IReviewService reviewService,
            IFavoriteService favoriteService)
        {
            _userService = userService;
            _purchaseService = purchaseService;
            _reviewService = reviewService;
            _favoriteService = favoriteService;

        }

        [HttpGet]
        [Route("{id:int}/puechase")]
        public async Task<IActionResult> GetUserPurchases(int id)
        {
            var purchases = await _userService.GetPurchasedMovies(id);
            if (purchases == null)
            {
                return NotFound("No Purchased Movie");
            }
            return Ok(purchases);
        }
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> UserPurchaseMovies([FromBody]UserPurchaseMovieRequestModel model)
        {
            var purchase = await _purchaseService.PurchaseMovie(model);
            if (purchase==null)
            {
                return NotFound("No Purchased Movie");
            }
            return Ok(purchase);
        }

        [HttpGet]
        [Route("{id:int}/favorite")]
        public async Task<IActionResult> GetUserFavorites(int id)
        {
            var favorites = await _favoriteService.GetFavoriteMovies(id);
            if (favorites == null)
            {
                return NotFound("No Favorite Movie");
            }
            return Ok(favorites);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> UserFavoriteMovie([FromBody]UserFavoriteRequestModel model)
        {
            var favorite = await _favoriteService.AddFavoriteMovie(model);
            if (favorite == null)
            {
                return NotFound("No Favorite Movie");
            }
            return Ok(favorite);
        }
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviews(int id)
        {
            var reviews = await _reviewService.GetUserReviews(id);
            if (reviews == null)
            {
                return NotFound("No Reviews");
            }
            return Ok(reviews);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddMovieReview([FromBody] UserReviewRequestModel model)
        {
            var review = await _reviewService.AddMovieReview(model);
            if (review == null)
            {
                return NotFound("No Review");
            }
            return Ok(review);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview([FromBody] UserReviewRequestModel model)
        {
            var review = await _reviewService.UpdateUserReview(model);
            if (review == null)
            {
                return NotFound("No Review");
            }
            return Ok(review);
        }

        [HttpDelete]
        [Route("{UserId:int}/movie/{MovieId:int}")]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }
    }
}