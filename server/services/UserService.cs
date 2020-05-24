using System.Linq;
using Server.Data;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Text;

namespace Server.Services
{
  public interface IUSerService
  {
    string Authenticate(string username, string password);
  }

  public class UserService : IUSerService
  {

    readonly UserContext _context;
    public UserService(UserContext context)
    {
      _context = context;
    }

    public string Authenticate(string username, string password)
    {
      var user = _context.Users.FirstOrDefault(user => user.UserName == username);

      if (user == null)
        return null;

      var comparePasswords = BCrypt.Net.BCrypt.Verify(password, user.Password);

      if (!comparePasswords)
        return null;

      var key = Encoding.ASCII.GetBytes("//TODO: Change me");
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
          new Claim(ClaimTypes.Name, user.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}