using System.Linq;
using Server.Data;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Text;
using Models.DataObjects;
using Server.Models.InputModels;
using Server.Models.OutputModels;

namespace Server.Services
{
  public interface IUSerService
  {
    AuthModel Authenticate(string username, string password);
    AuthModel Register(RegisterModel registerModel);
    bool IfUserExists(string userName);
  }

  public class UserService : IUSerService
  {

    readonly UserContext _context;
    public UserService(UserContext context)
    {
      _context = context;
    }

    public AuthModel Authenticate(string username, string password)
    {
      var user = _context.Users.FirstOrDefault(u => u.UserName == username);

      if (user == null)
        return null;

      var comparePasswords = BCrypt.Net.BCrypt.Verify(password, user.Password);

      if (!comparePasswords)
        return null;

      var token = CreateToken(user.Id);

      var auth = (AuthModel)user;
      auth.Token = token;

      return auth;
    }

    public AuthModel Register(RegisterModel registerModel)
    {
      // TODO: Consider adding a user creating class
      var user = new User
      {
        Id = new Guid(),
        UserName = registerModel.UserName,
        Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
        RegisteredAt = DateTime.UtcNow,
        DisplayName = registerModel.DisplayName,
        BirthDate = registerModel.BirthDate,
        Bio = registerModel.Bio
      };

      _context.Users.Add(user);
      _context.SaveChangesAsync();

      var token = CreateToken(user.Id);

      var auth = (AuthModel)user;
      auth.Token = token;

      return auth;
    }

    public bool IfUserExists(string userName) =>
      _context.Users.Any(user => user.UserName == userName);

    static string CreateToken(Guid userId)
    {
      var key = Encoding.ASCII.GetBytes("//TODO: Change me");
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
          new Claim(ClaimTypes.Name, userId.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}