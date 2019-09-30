using Microsoft.EntityFrameworkCore;
using System;

namespace ApiServer.Models
{
  public class TestDbContext : DbContext
  {
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
  }
}