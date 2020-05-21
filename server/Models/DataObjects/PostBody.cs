using System;
using System.Collections.Generic;

namespace Models.DataObjects
{
  /// <summary>
  /// This is the content for each post. The reason this is it's own is because not every post will contain content
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