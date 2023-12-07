using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     Represents the 'Delete Forest' page in the Forest Web App for functional testing.
/// </summary>
/// <param name="driver">The WebDriver instance used for browser interactions.</param>
/// <param name="forestName">The name of the forest to be deleted.</param>
/// <param name="forestId">The ID of the forest to be deleted.</param>
/// <param name="url">The base URL of the Delete page.</param>
public class DeletePage(IWebDriver driver, string forestName, string forestId, string url)
    : BasePage(driver, url + forestId)
{
    /// <summary>
    ///     the input fields on the Delete page
    /// </summary>
    private static By ForestName => By.Id("ForestName");

    private By CountryOfOrigin => By.Id($"[{forestName}]CountryOfOrigin");
    private By TypeOfVegetation => By.Id($"[{forestName}]TypeOfVegetation");
    private By AreaKm2 => By.Id($"[{forestName}]AreaKm2");
    private By OldGrowthForest => By.Id($"[{forestName}]OldGrowthForest");
    private static By DeleteForestSubmitButton => By.Id("deleteForestSubmitBtn");

    /// <summary>
    ///     Gets the name of the forest from the Delete page.
    /// </summary>
    /// <returns>The name of the forest.</returns>
    public string? GetForestName()
    {
        return GetText(ForestName);
    }

    /// <summary>
    ///     Gets the country of origin of the forest from the Delete page.
    /// </summary>
    /// <returns>The country of origin of the forest.</returns>
    public string? GetCountryOfOrigin()
    {
        return GetText(CountryOfOrigin);
    }

    /// <summary>
    ///     Gets the type of vegetation of the forest from the Delete page.
    /// </summary>
    /// <returns>The type of vegetation of the forest.</returns>
    public string? GetTypeOfVegetation()
    {
        return GetText(TypeOfVegetation);
    }

    /// <summary>
    ///     Gets the area (in Km2) of the forest from the Delete page.
    /// </summary>
    /// <returns>The area of the forest in square kilometers.</returns>
    public string? GetAreaKm2()
    {
        return GetText(AreaKm2);
    }

    /// <summary>
    ///     Gets the old growth forest status from the Delete page.
    /// </summary>
    /// <returns>The old growth forest status as a string.</returns>
    public string? GetOldGrowthForestStatus()
    {
        return GetText(OldGrowthForest);
    }

    /// <summary>
    ///     Clicks the button to submit the forest deletion on the Delete page.
    /// </summary>
    public void ClickDeleteForestSubmitButton()
    {
        Click(DeleteForestSubmitButton);
    }
}