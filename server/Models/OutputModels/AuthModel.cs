using System;

namespace Server.Models.OutputModels
{
  public class AuthModel
  {
    public string UserName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Bio { get; set; }
    public string Token { get; set; }
  }
}