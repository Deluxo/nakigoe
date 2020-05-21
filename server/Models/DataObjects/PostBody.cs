using System;
using System.Collections.Generic;

namespace Models.DataObjects
{
  /// <summary>
  /// This i
  /// </summary>
  public class PostBody
  {
    public Guid Id { get; set; }
    public User User { get; set; }
    public DateTime PostedOn { get; set; }
    public List<string> Images { get; set; }
    public string Body { get; set; }
  }
}