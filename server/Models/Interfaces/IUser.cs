using System;

namespace Server.Models.Interfaces
{
  public interface IUSer
  {
    string UserName { get; set; }
    string Password { get; set; }
    DateTime BirthDate { get; set; }
    string DisplayName { get; set; }
  }
}
