using ForestWebApp.Models;

namespace ForestWebApp.Data;

/// <summary>
///     Class to initialize forest data in the database.
/// </summary>
public static class ForestDataInitializer
{
    /// <summary>
    ///     Method to initialize forest data in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    public static void Initialize(ForestWebAppContext context)
    {
        context.Database.EnsureCreated();
        
        if (context.Forest.Any()) return;
        
        var forests = new Forest[]
        {
            new()
            {
                Name = "Selva Amazónica",
                CountryOfOrigin = "Brasil",
                TypeOfVegetation = "Selva Tropical",
                AreaKm2 = 5500000,
                OldGrowthForest = true
            },
            new()
            {
                Name = "Bosque de Fontainebleau",
                CountryOfOrigin = "Francia",
                TypeOfVegetation = "Bosque Caducifolio",
                AreaKm2 = 280,
                OldGrowthForest = false
            },
            new()
            {
                Name = "Bosque Nuboso Monteverde",
                CountryOfOrigin = "Costa Rica",
                TypeOfVegetation = "Bosque Nuboso",
                AreaKm2 = 105,
                OldGrowthForest = true
            }
        };

        context.Forest.AddRange(forests);
        context.SaveChanges();
    }
}