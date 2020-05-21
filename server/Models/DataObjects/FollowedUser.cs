using System;

namespace Models.DataObjects
{
  /// <summary>
  /// So when a person follows somebody there needs to be a way
  /// for that person to myte the person they are following 
  /// </summary>
  public class FollowedUser
  {
    public Guid Id { get; set; }
    public User User { get; set; }
    public bool SeePosts { get; set; }
    public bool SeeReposts { get; set; }
  }
}