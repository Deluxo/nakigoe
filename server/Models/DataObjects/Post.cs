using System;

namespace Models.DataObjects
{
  public class Post
  {
    public Guid Id { get; set; }
    /// <summary>
    /// The person who made the post who doesn't have to be the person in the body of the post if it's a reblog
    /// </summary>
    /// <value>The person who made the post</value>
    public User Poster { get; set; }
    public DateTime Date { get; set; }
    public PostType Type { get; set; }
    public PostBody Content { get; set; }
    /// <summary>
    /// If it's a reply this can be used to display the thread
    /// </summary>
    /// <value>The post replied to</value>
    public Post ReplyTo { get; set; }
    // public List<Like> Likes {get;set;}
  }
}