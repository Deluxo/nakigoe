using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Server.Data;
using Models.DataObjects;

namespace Server.Services
{
  public class DatabaseSeeder
  {
    public static void CreateAdmin(IServiceProvider serviceProvider)
    {
      var context = serviceProvider.GetRequiredService<UserContext>();

      if (context.Users.Any())
        return;

      var user = new User
      {
        Id = Guid.NewGuid(),
        UserName = "Admin",
        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
        RegisteredAt = DateTime.Now,
        DisplayName = "一番アドミン",
        BirthDate = DateTime.Now
      };

      context.Users.Add(user);
      context.SaveChanges();
    }
  }
}