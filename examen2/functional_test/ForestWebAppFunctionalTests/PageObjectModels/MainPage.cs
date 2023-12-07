using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     This class is the main page of the Forest Web App.
/// </summary>
/// <param name="driver"> The web driver to use. </param>
/// <param name="url"> The url of the page. </param>
public class MainPage(IWebDriver driver, string url) : BasePage(driver, url)
{
    /// <summary>
    ///     the buttons in the nav bar
    /// </summary>
    private static By HomeLink => By.Id("HomeLink");

    private static By AboutPageButton => By.Id("AboutPageButton");

    /// <summary>
    ///     checks if the home link is displayed
    /// </summary>
    /// <returns> true if the home link is displayed, false otherwise </returns>
    public bool IsHomeLinkDisplayed()
    {
        return IsDisplayed(HomeLink);
    }

    /// <summary>
    ///     checks if the about page button is displayed
    /// </summary>
    /// <returns> true if the about page button is displayed, false otherwise </returns>
    public bool IsAboutPageButtonDisplayed()
    {
        return IsDisplayed(AboutPageButton);
    }
}