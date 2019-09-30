using Microsoft.EntityFrameworkCore;
using System;

namespace csvToDatabase.Models
{
    public class PDDbContext : DbContext
    {
        public PDDbContext(DbContextOptions<PDDbContext> options) : base(options) {}

        public DbSet<Runway> Runways {get; set;}
    }
}