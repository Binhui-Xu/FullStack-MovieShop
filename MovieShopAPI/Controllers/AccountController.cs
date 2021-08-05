using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLoginRequestModel model)
        {
            //chekc if the user has entered correct un/pw
            var user = await _userService.Login(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
        
            //if user entered valid us/pw
            //create JWT Token
            var jwtToken = GenerateJWT(user);
            return Ok(new { token = jwtToken });//new {}  => means anonymous object
        }

        private string GenerateJWT(UserLoginResponseModel model)
        {
            //we will use the token libriaries to create tokens

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,model.LastName)
            };
            //create identity object and strore claims
            var indentityClaim = new ClaimsIdentity();
            indentityClaim.AddClaims(claims);

            //read the secret key from appsetting, make sure secret key is unique and nor guessable
            //In real world we use something like Azure KeyVaule to store any secret of application
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //get the expiration time of the token
            var expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JwtSettings:Expiration"));
            //pick an hashing algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the token object that u will use to create the token that will include all the information
            //such as credentials, claims, expiration time
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject= indentityClaim,
                Expires=expires,
                SigningCredentials=credentials,
                Issuer=_configuration["JwtSettings:Issuer"],
                Audience=_configuration["JwtSettings:Audience"]
                
            };
            var encodedJwt = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(encodedJwt);
        }

        [HttpPost]
        [Route("register")]
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

        

        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            return Ok();
        }
    }
}