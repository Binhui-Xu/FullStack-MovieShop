using System;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private ICurrentUser _currentUser;
        private IUserService _userService;
        private IPurchaseService _purchaseService;
        public UserController(ICurrentUser currentUser,IUserService userService,IPurchaseService purchaseService)
        {
            _currentUser = currentUser;
            _userService = userService;
            _purchaseService = purchaseService;
        }

        public async Task<IActionResult> PurchasedMovies()
        {
            var userid = _currentUser.UserId;
            var moviecard =await _userService.GetPurchasedMovies(userid);
            return View(moviecard);
        }

        public async Task<IActionResult> ViewUserProfile()
        {
            var email = _currentUser.Email;
            var user =await _userService.GetUserDetails(email);
            return View(user);
        }
        [HttpGet]
        public IActionResult ConfirmPurchase(int mid)
        {
            var purchaseMovie = new UserPurchaseMovieRequestModel();
            purchaseMovie.MovieId = mid;
            purchaseMovie.UserId = _currentUser.UserId;
            // purchaseMovie.TotalPrice = price;
            return View(purchaseMovie);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmPurchase(UserPurchaseMovieRequestModel model)
        {
            var createPurchase = await _purchaseService.PurchaseMovie(model);
            return Redirect("~/");
        }
        
    }
}