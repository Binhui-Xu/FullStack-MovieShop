using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        //method for registration
        //show the empty view that will have all the text boxes and submit button
        //localhost/account/registration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        //if the form attribute huge, can simply use the model directly
        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            //save the data only when Model validation passes
            if (!ModelState.IsValid)
            {
                //save to DB
                return View();
            }
            var createUsre =await _userService.RegisterUser(model);
            //redirect to login page
            
            //Model Binding not case senstive
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userService.Login(model.Email,model.Password);
            if (user == null)
            {
                //wrong password
                ModelState.AddModelError(string.Empty,"Invalid password");
                return View();
            }

            //correct password
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.LastName),
                new Claim(ClaimTypes.Surname,user.FirstName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())

            };





            //display, firstname, lastname, email
            //button,link for logout
            //Cookie based Authentication...
            //e.g. 10:00AM you login webste
            //created a MovieShopAuthCookie => 2hours exprision time
            //Claims,firstname,lastname,id,email - encrypt this info and store in cookie
            //every time you send a request from browser to server => cookies are sent to server sutomatically

            //make sure user is login successfully
            //movies/details/22 =>but button
            //when you click on buy button => POST
            //purchase table => movieid and userid
            //user/buymovie => should take userid from cookie and send to database
            //10:15 AM you wanna buy a movie 
            //10:30 AM you wanna favorite a movie
            return View();
            
        }
    }
}