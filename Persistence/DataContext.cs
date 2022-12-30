using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        // Empty
    }
    
    // Represents the tables that will be created
    public DbSet<Activity> Activities { get; set; }
}