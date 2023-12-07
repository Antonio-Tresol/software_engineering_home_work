using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     A page object model for the create page of the Forest Web App.
/// </summary>
/// <param name="driver"> The WebDriver instance used for browser interactions. </param>
/// <param name="url"> The URL of the Create page. </param>
public class CreatePage(IWebDriver driver, string url) : BasePage(driver, url)
{
    /// <summary>
    ///     the input fields on the create page
    /// </summary>
    private static By ForestNameInput => By.Id("Forest_Name");

    private static By CountryOfOriginSelect => By.Id("Forest_CountryOfOrigin");
    private static By TypeOfVegetationInput => By.Id("Forest_TypeOfVegetation");
    private static By AreaKm2Input => By.Id("Forest_AreaKm2");
    private static By OldGrowthForestCheckbox => By.Id("Forest_OldGrowthForest");
    private static By CreateForestSubmitButton => By.Id("createForestSubmitBtn");

    /// <summary>
    ///     enters the forest name into the forest name input field
    /// </summary>
    /// <param name="name"> the name to enter </param>
    public void EnterForestName(string name)
    {
        EnterText(ForestNameInput, name);
    }

    /// <summary>
    ///     selects the country of origin from the country of origin select
    /// </summary>
    /// <param name="country"> the country to select </param>
    public void SelectCountryOfOrigin(string country)
    {
        var selectElement = new SelectElement(Find(CountryOfOriginSelect));
        selectElement.SelectByText(country);
    }

    /// <summary>
    ///     enters the type of vegetation into the type of vegetation input field
    /// </summary>
    /// <param name="vegetationType"> the type of vegetation to enter </param>
    public void EnterTypeOfVegetation(string vegetationType)
    {
        EnterText(TypeOfVegetationInput, vegetationType);
    }

    /// <summary>
    ///     enters the area in km2 into the area in km2 input field
    /// </summary>
    /// <param name="area"> the area in km2 to enter </param>
    public void EnterAreaKm2(string area)
    {
        EnterText(AreaKm2Input, area);
    }

    /// <summary>
    ///     sets the old growth forest checkbox to checked or unchecked
    /// </summary>
    /// <param name="isChecked"> true if the checkbox should be checked, false otherwise </param>
    public void SetOldGrowthForest(bool isChecked)
    {
        var checkbox = Find(OldGrowthForestCheckbox);
        if (checkbox != null && ((checkbox.Selected && !isChecked) || (!checkbox.Selected && isChecked)))
            Click(OldGrowthForestCheckbox);
    }

    /// <summary>
    ///     clicks the create forest submit button
    /// </summary>
    public void SubmitCreateForest()
    {
        Click(CreateForestSubmitButton);
    }
}