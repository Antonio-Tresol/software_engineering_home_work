using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     a page object model that represents the edit page of the forest app
/// </summary>
/// <param name="driver"> The web driver to use. </param>
/// <param name="forestId"> The id of the forest to edit. </param>
/// <param name="url"> The url of the page. </param>
public class EditPage(IWebDriver driver, string forestId, string url)
    : BasePage(driver, url + forestId)
{
    /// <summary>
    ///     input fields for the edit page
    /// </summary>
    private static By ForestNameInput => By.Id("Forest_Name");

    private static By CountryOfOriginSelect => By.Id("Forest_CountryOfOrigin");
    private static By TypeOfVegetationInput => By.Id("Forest_TypeOfVegetation");
    private static By AreaKm2Input => By.Id("Forest_AreaKm2");
    private static By OldGrowthForestCheckbox => By.Id("Forest_OldGrowthForest");

    /// <summary>
    ///     submit button for the edit page
    /// </summary>
    private static By EditForestSubmitButton => By.Id("editForestSubmitBtn");

    /// <summary>
    ///     enters the forest name into the forest name input field
    /// </summary>
    /// <param name="name"> the forest name to enter </param>
    public void EnterForestName(string name)
    {
        EnterText(ForestNameInput, name);
    }

    /// <summary>
    ///     selects the country of origin from the country of origin select field
    /// </summary>
    /// <param name="country"> the country of origin to select </param>
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
    /// <param name="isChecked"> whether the checkbox should be checked or unchecked </param>
    public void SetOldGrowthForest(bool isChecked)
    {
        var checkbox = Find(OldGrowthForestCheckbox);
        if (checkbox != null && ((checkbox.Selected && !isChecked) || (!checkbox.Selected && isChecked)))
            Click(OldGrowthForestCheckbox);
    }

    /// <summary>
    ///     submits the edit forest form
    /// </summary>
    public void SubmitEditForest()
    {
        Click(EditForestSubmitButton);
    }
}