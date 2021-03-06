using System;
using Microsoft.AspNetCore.Http;
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
    public IFormFile ProfilePicture { get; set; }
  }
}