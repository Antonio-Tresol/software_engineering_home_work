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
            new Forest
            {
                Id = new Guid("2A9D2B53-82DF-4F10-DF04-08DBF7103086"),
                Name = "Selva Amazónica",
                CountryOfOrigin = "Brasil",
                TypeOfVegetation = "Selva Tropical",
                AreaKm2 = 5500000,
                OldGrowthForest = true
            },
            new Forest
            {
                Id = new Guid("FFCC82F7-100D-4169-DF05-08DBF7103086"),
                Name = "Bosque de Fontainebleau",
                CountryOfOrigin = "Francia",
                TypeOfVegetation = "Bosque Caducifolio",
                AreaKm2 = 280,
                OldGrowthForest = false
            },
            new Forest
            {
                Id = new Guid("F5B97F96-D133-44A6-DF06-08DBF7103086"),
                Name = "Bosque Nuboso Monteverde",
                CountryOfOrigin = "Costa Rica",
                TypeOfVegetation = "Bosque Nuboso",
                AreaKm2 = 105,
                OldGrowthForest = true
            },
            new Forest
            {
                Id = new Guid("FD8955AA-EB9F-41E9-DF07-08DBF7103086"),
                Name = "Taiga Siberiana",
                CountryOfOrigin = "Rusia",
                TypeOfVegetation = "Taiga",
                AreaKm2 = 10000000,
                OldGrowthForest = true
            },
            new Forest
            {
                Id = new Guid("2A46F37C-674E-4B8C-DF08-08DBF7103086"),
                Name = "Bosque de Aokigahara",
                CountryOfOrigin = "Japón",
                TypeOfVegetation = "Bosque de Coníferas",
                AreaKm2 = 35,
                OldGrowthForest = true
            }
        };

        context.Forest.AddRange(forests);
        context.SaveChanges();
    }
}