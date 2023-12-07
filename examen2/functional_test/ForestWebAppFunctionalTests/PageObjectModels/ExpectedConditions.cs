using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     This class contains methods that represent the expected conditions of a web page.
/// </summary>
public static class ExpectedConditions
{
    /// <summary>
    ///     Checks if an element exists.
    /// </summary>
    /// <param name="locator"></param>
    /// <returns></returns>
    public static Func<IWebDriver, IWebElement?> ElementExists(By locator)
    {
        return driver =>
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        };
    }

    /// <summary>
    ///     Checks if an element is visible.
    /// </summary>
    /// <param name="locator"> The selector to use. </param>
    /// <returns> web element or null if does not exist</returns>
    public static Func<IWebDriver, IWebElement?> ElementIsVisible(By locator)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        };
    }

    /// <summary>
    ///     Checks if an element is clickable.
    /// </summary>
    /// <param name="locator"> The selector to use. </param>
    /// <returns> web element or null if does not exist</returns>
    public static Func<IWebDriver, IWebElement?> ElementToBeClickable(By locator)
    {
        return driver =>
        {
            var element = ElementIsVisible(locator)(driver);
            try
            {
                return element is { Enabled: true } ? element : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }
}