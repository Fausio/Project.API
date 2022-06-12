using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Entity;
using Project.Data.Entity.Model;
using Project.Web.API.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.API.Controllers
{
    public class JWTTokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JWTTokenController(SignInManager<ApplicationUser> signInManager, 
                                  UserManager<ApplicationUser>  userManager
                                )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
       
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]

        public async Task<IActionResult> CreateToken([FromBody] ImputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, false);
            if (result.Succeeded)
            {
                var token = new TokenJWTBuilder().AddSecurityKey(JWTSecurityKey.Create("Secret_Key-12345678"))
                                                 .AddSubject("Genesys Code")
                                                 .AddIssuer("Test.Securiry.Bearer")
                                                 .AddAudience("test.Securiry.Bearer")
                                                 .AddClaim("UserAPINumber", "1")
                                                 .AddExpiry(5)
                                                 .Builder();
                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
