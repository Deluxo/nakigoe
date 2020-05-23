using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.DataObjects;

namespace Server.Data
{
  public class UserContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostBody> PostBodies { get; set; }
    public DbSet<FollowedUser> FollowedUsers { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
  }
}