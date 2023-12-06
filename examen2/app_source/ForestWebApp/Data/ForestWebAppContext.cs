using ForestWebApp.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for data context
namespace ForestWebApp.Data;

/// <summary>
///     Class for the application's database context.
///     This class inherits from the DbContext class provided by Entity Framework Core.
/// </summary>
public class ForestWebAppContext : DbContext
{
    /// <summary>
    ///     Constructor for the ForestWebAppContext class.
    ///     Initializes a new instance of the ForestWebAppContext class using the specified options.
    /// </summary>
    /// <param name="options">The options to be used by a DbContext.</param>
    public ForestWebAppContext(DbContextOptions<ForestWebAppContext> options)
        : base(options)
    {
    }

    /// <summary>
    ///     Gets or sets the DbSet of Forest objects that represents the Forest table in the database.
    /// </summary>
    public DbSet<Forest> Forest { get; set; } = default!;
}