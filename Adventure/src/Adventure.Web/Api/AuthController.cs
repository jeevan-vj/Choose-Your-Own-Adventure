using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Adven.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Adventure.Web.Api;

public class AuthController : BaseApiController
{
  [HttpPost]
  [Route("login")]
  public IActionResult Login(LoginDto model)
  {
    if (model == null)
    {
      return BadRequest("Invalid client request");
    }

    if (model.UserName == "advenuser" && model.Password == "SuperStrongPassword")
    {
      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
      var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

      var tokenOptions = new JwtSecurityToken(
        claims: new List<Claim> {new("UserId", "1")},
        expires: DateTime.Now.AddMinutes(50),
        signingCredentials: signinCredentials
      );

      var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
      return Ok(new {Token = tokenString});
    }

    return Unauthorized();
  }
}
