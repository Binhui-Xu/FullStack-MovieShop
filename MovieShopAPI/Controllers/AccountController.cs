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
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            var createdUser = await _userService.RegisterUser(model);
            //send the URL for newly create user also
            //5000

            return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser);
            //201
        }
        

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequestModel model)
        {
            var login = await _userService.Login(model.Email, model.Password);
            if (login == null)
            {
                return NotFound("No User");
            }
            return Ok(login);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            return Ok();
        }
    }
}