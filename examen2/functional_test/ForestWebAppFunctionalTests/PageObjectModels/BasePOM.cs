using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     A base class for all page object models.
/// </summary>
/// <param name="driver"> The web driver to use. </param>
/// <param name="url"> The url of the page. </param>
public abstract class BasePage(IWebDriver driver, string url)
{
    /// <summary>
    ///     The web driver to use.
    /// </summary>
    private readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(3));

    /// <summary>
    ///     The url of the page.
    /// </summary>
    /// <param name="by"></param>
    protected void Click(By by)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(by))?.Click();
    }

    /// <summary>
    ///     Navigates to the page.
    /// </summary>
    public void GoToPage()
    {
        driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    ///     Enters text into a text field.
    /// </summary>
    protected void EnterText(By by, string text)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(by))?.SendKeys(text);
    }

    /// <summary>
    ///     Finds an element on the page.
    /// </summary>
    /// <param name="by"> The selector to use. </param>
    /// <returns> web element or null if does not exist</returns>
    public IWebElement? Find(By by)
    {
        return _wait.Until(ExpectedConditions.ElementExists(by));
    }

    /// <summary>
    ///     Gets the text of an element.
    /// </summary>
    /// <param name="by"> The selector to use. </param>
    /// <returns> text of element or null if does not exist</returns>
    protected string? GetText(By by)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(by))?.Text;
    }

    /// <summary>
    ///     Checks if an element is displayed.
    /// </summary>
    /// <param name="by"> The selector to use. </param>
    /// <returns> true if displayed, false otherwise </returns>
    protected bool IsDisplayed(By by)
    {
        try
        {
            return Find(by)!.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}