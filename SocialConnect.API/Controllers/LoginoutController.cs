
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialConnect.Core.DTO;
using SocialConnect.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  // [ApiExplorerSettings(GroupName = "Loginout")]
    public class LoginoutController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signmanager;
        // UnitOfwork db;

        public LoginoutController( UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signmanager)
        {
            //this.db = db;
            this.userManager = userManager;
            this.signmanager = signmanager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin cs)
        {
            if (ModelState.IsValid)
            {
                var rs = signmanager.PasswordSignInAsync(cs.username, cs.password, false, false).Result;
                if (rs.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(cs.username);
                    #region generate token

                    List<Claim> userdata = new List<Claim>();
                    userdata.Add(new Claim(ClaimTypes.Name, user.UserName));
                    userdata.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Any())
                    {
                        userdata.Add(new Claim(ClaimTypes.Role, roles.First()));
                    }
                    string key = "My Complex Secret Key My Complex Secret Key My Complex Secret Key";
                    var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

                    var signingcer = new SigningCredentials(secertkey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                    claims: userdata,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingcer
                    );
                    var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenstring);
                    #endregion
                }
                else
                    return Unauthorized();
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            signmanager.SignOutAsync();
            //token will be not valid 
            return Ok();
        }
    }
}
