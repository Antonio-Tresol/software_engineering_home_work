using ForestWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestWebApp.Data;

/// <summary>
///     ForestRepository class that implements IForestRepository interface.
///     Provides methods for interacting with Forest data in the database.
/// </summary>
public class ForestRepository(ForestWebAppContext context, ILogger<ForestRepository> logger) : IForestRepository
{
    /// <inheritdoc />
    public async Task<Forest?> GetForestAsync(Guid id)
    {
        try
        {
            var forest = await context.Forest.FirstOrDefaultAsync(m => m.Id == id);
            return forest;
        }
        catch (Exception e)
        {
            LogError("GetForestAsync", e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Forest>> GetForestsAsync()
    {
        try
        {
            var forests = await context.Forest.ToListAsync();
            return forests;
        }
        catch (Exception e)
        {
            LogError("GetForestsAsync", e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task AddForestAsync(Forest forest)
    {
        if (ForestExists(forest))
            throw new ArgumentException("Forest exist already");
        try
        {
            context.Forest.Add(forest);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            LogError("AddForestAsync", e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task UpdateForestAsync(Forest forest)
    {
        if (!ForestExists(forest))
            throw new ArgumentException("Forest Does not exist");
        try
        {
            context.Attach(forest).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            LogError("UpdateForestAsync", e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task DeleteForestAsync(Forest forest)
    {
        if (!ForestExists(forest))
            throw new ArgumentException("Forest Does not exist");
        try
        {
            context.Forest.Remove(forest);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            LogError("DeleteForestAsync", e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<Forest?> GetForestByAttributes(string name, string country, string vegetation, int area,
        bool oldGrowthForest)
    {
        try
        {
            var forest = await context.Forest.FirstOrDefaultAsync(f =>
                f.Name == name && f.CountryOfOrigin == country && f.OldGrowthForest == oldGrowthForest &&
                f.TypeOfVegetation == vegetation);
            return forest;
        }
        catch (Exception e)
        {
            LogError("GetForestByAttributes", e);
            throw;
        }
    }

    /// <summary>
    ///     logs and error comming from a method.
    /// </summary>
    /// <param name="methodName"> the method name</param>
    /// <param name="e"> the catched exception </param>
    private void LogError(string methodName, Exception e)
    {
        var message = "Forest Repository error on method (" + methodName + "): " + e.Message;
        logger.LogError(message);
    }

    /// <summary>
    ///     tells if a forest exist or not.
    /// </summary>
    /// <param name="forest">a forest to check</param>
    /// <returns></returns>
    private bool ForestExists(Forest forest)
    {
        return context.Forest.Any(e => e.Id == forest.Id);
    }
}