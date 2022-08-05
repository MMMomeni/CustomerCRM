using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync accountServiceAsync;

        //we have to inject this to be able to configure in Login
        private readonly IConfiguration configuration;
        public AccountController(IAccountServiceAsync accountServiceAsync, IConfiguration config)
        {
            this.accountServiceAsync = accountServiceAsync;
            this.configuration = config;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await accountServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User has been created successfully" });
            }
            // In case if there is an error
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description); 
            }
            return BadRequest(sb.ToString());

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await accountServiceAsync.LoginAsync(model); 
            if (!result.Succeeded)
                return Unauthorized(new {Message = "Invalid Username and Password"});


            /* list of claims
             * We can validate tokens with the below lines
             * Jti is a predefind claim that allow us to give Guid (unique Identifier)
             */
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience:configuration["JWT:ValidAudience"],
                expires:DateTime.Now.AddDays(1),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            // Now we need to use token handler that returns the token in the output.
            var t = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {jwt = t});
        }
    }
}
