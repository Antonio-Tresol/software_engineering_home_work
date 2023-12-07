using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     a page object model for the details page
/// </summary>
/// <param name="driver"> the web driver to use </param>
/// <param name="forestName"> the name of the forest </param>
/// <param name="forestId"> the id of the forest </param>
/// <param name="url"> the url of the page </param>
public class DetailsPage(IWebDriver driver, string forestName, string forestId, string url)
    : BasePage(driver, url + forestId)
{
    /// <summary>
    ///     the elements on the details page
    /// </summary>
    private static By ForestName => By.Id("ForestName");

    private By CountryOfOrigin => By.Id($"[{forestName}]CountryOfOrigin");
    private By TypeOfVegetation => By.Id($"[{forestName}]TypeOfVegetation");
    private By AreaKm2 => By.Id($"[{forestName}]AreaKm2");
    private By OldGrowthForest => By.Id($"[{forestName}]OldGrowthForest");

    /// <summary>
    ///     gets the name of the forest
    /// </summary>
    /// <returns> the name of the forest or null if it doesn't exist </returns>
    public string? GetForestName()
    {
        return GetText(ForestName);
    }

    /// <summary>
    ///     gets the country of origin of the forest
    /// </summary>
    /// <returns> the country of origin of the forest or null if it doesn't exist </returns>
    public string? GetCountryOfOrigin()
    {
        return GetText(CountryOfOrigin);
    }

    /// <summary>
    ///     gets the type of vegetation of the forest
    /// </summary>
    /// <returns> the type of vegetation of the forest or null if it doesn't exist </returns>
    public string? GetTypeOfVegetation()
    {
        return GetText(TypeOfVegetation);
    }

    /// <summary>
    ///     gets the area of the forest
    /// </summary>
    /// <returns> the area of the forest or null if it doesn't exist </returns>
    public string? GetAreaKm2()
    {
        return GetText(AreaKm2);
    }

    /// <summary>
    ///     gets the old growth forest status of the forest
    /// </summary>
    /// <returns> the old growth forest status of the forest or null if it doesn't exist </returns>
    public string? GetOldGrowthForestStatus()
    {
        return GetText(OldGrowthForest);
    }
}