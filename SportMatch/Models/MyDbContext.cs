using Microsoft.EntityFrameworkCore;

namespace SportMatch.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Venue> Venues { get; set; }
}