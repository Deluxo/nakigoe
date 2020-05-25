using System;
using Server.Models.Interfaces;

namespace Server.Models.InputModels
{
  public class RegisterModel : IUSer
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string DisplayName { get; set; }
  }
}