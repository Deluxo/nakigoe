using System;
using System.Collections.Generic;
using Server.Models.Interfaces;

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
  }
}