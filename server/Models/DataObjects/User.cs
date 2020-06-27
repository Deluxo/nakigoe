using System;
using System.Collections.Generic;
using Server.Models.InputModels;
using Server.Models.Interfaces;
using Server.Models.OutputModels;

namespace Models.DataObjects
{
  public class User : IUSer
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime RegisteredAt { get; set; }

    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public DateTime BirthDate { get; set; }

    public List<FollowedUser> Following { get; set; }

    public string ProfilePic { get; set; }

    public static explicit operator AuthModel(User model) =>
      new AuthModel
      {
        UserName = model.UserName,
        BirthDate = model.BirthDate,
        DisplayName = model.DisplayName,
        Bio = model.Bio
      };
  }
}