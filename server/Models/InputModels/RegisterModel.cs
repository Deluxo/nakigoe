using System;
using Server.Models.Interfaces;
using Server.Models.OutputModels;

namespace Server.Models.InputModels
{
  public class RegisterModel : IUSer
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }

    public static explicit operator AuthModel(RegisterModel model) =>
      new AuthModel
      {
        UserName = model.UserName,
        BirthDate = model.BirthDate,
        DisplayName = model.DisplayName,
        Bio = model.Bio
      };
  }
}