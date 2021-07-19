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
            //display, firstname, lastname, email
            //button,link for logout
            //Cookie based Authentication...
            return View();
            
        }
    }
}