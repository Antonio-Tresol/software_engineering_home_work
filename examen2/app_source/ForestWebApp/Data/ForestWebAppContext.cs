using ForestWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestWebApp.Data;

public class ForestWebAppContext : DbContext
{
    public ForestWebAppContext (DbContextOptions<ForestWebAppContext> options)
        : base(options)
    {
    }

    public DbSet<Forest> Forest { get; set; } = default!;
}