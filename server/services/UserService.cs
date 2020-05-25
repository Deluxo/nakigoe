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

      return CreateToken(user.Id);
    }

    public string Register(RegisterModel registerModel)
    {
      // TODO: Consider adding a user creating class
      var user = new User
      {
        Id = new Guid(),
        UserName = registerModel.UserName,
        Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
        RegisteredAt = DateTime.UtcNow,
        DisplayName = registerModel.DisplayName,
        BirthDate = registerModel.BirthDate
      };

      _context.Users.Add(user);
      _context.SaveChangesAsync();

      return CreateToken(user.Id);
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