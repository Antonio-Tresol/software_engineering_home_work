using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     This class is the index page of the Forest Web App.
/// </summary>
/// <param name="driver"> The web driver to use. </param>
/// <param name="url"> The url of the page. </param>
public class IndexPage(IWebDriver driver, string url) : BasePage(driver, url)
{
    /// <summary>
    ///     the elements on the index page
    /// </summary>
    private static By ForestTitle => By.Id("forestsTitle");

    private static By CreateForestButton => By.Id("createForestBtn");

    /// <summary>
    ///     get the index page title
    /// </summary>
    /// <returns> the index page title or null if it doesn't exist </returns>
    public string? GetForestTitle()
    {
        return GetText(ForestTitle);
    }

    /// <summary>
    ///     checks if the create forest button is displayed
    /// </summary>
    /// <param name="forestName"> the name of the forest </param>
    /// <returns> true if the create forest button is displayed, false otherwise </returns>
    public ForestDetails GetForestDetails(string forestName)
    {
        return new ForestDetails
        {
            Name = GetText(By.Id($"name[{forestName}]")),
            CountryOfOrigin = GetText(By.Id($"countryOfOrigin[{forestName}]")),
            TypeOfVegetation = GetText(By.Id($"typeOfVegetation[{forestName}]")),
            AreaKm2 = GetText(By.Id($"areaKm2[{forestName}]")),
            OldGrowthForest = GetText(By.Id($"oldGrowthForest[{forestName}]"))
        };
    }

    /// <summary>
    ///     checks if the create forest button is displayed
    /// </summary>
    /// <returns> true if the create forest button is displayed, false otherwise </returns>
    public bool IsCreateForestButtonDisplayed()
    {
        return IsDisplayed(CreateForestButton);
    }


    /// <summary>
    ///     the display details of a forest
    /// </summary>
    public class ForestDetails
    {
        public string? Name { get; set; }
        public string? CountryOfOrigin { get; set; }
        public string? TypeOfVegetation { get; set; }
        public string? AreaKm2 { get; set; }
        public string? OldGrowthForest { get; set; }
    }
}