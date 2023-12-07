using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class CreateTests
{
    private IWebDriver _driver = null!;
    private const string Url = "https://localhost:7130/Forests/Create";
    private CreatePage _createPage = null!;
    private IndexPage _indexPage = null!;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _createPage = new CreatePage(_driver, Url);
        _indexPage = new IndexPage(_driver, "https://localhost:7130/");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }
    /// <summary>
    ///    Test that the Create operation works as expected by creating a forest and checking that it is displayed in the index page.
    /// </summary>
    [Test]
    public void TestCreateForest()
    {
        // Arrange
        var forestTestDetails = new
        {
            Name = "Test Forest", CountryOfOrigin = "Francia", TypeOfVegetation = "Test Vegetation", AreaKm2 = "1000",
            OldGrowthForest = "Sí"
        };
        // Act
        _createPage.GoToPage();
        _createPage.EnterForestName(forestTestDetails.Name);
        _createPage.SelectCountryOfOrigin(forestTestDetails.CountryOfOrigin);
        _createPage.EnterTypeOfVegetation(forestTestDetails.TypeOfVegetation);
        _createPage.EnterAreaKm2(forestTestDetails.AreaKm2);
        _createPage.SetOldGrowthForest(forestTestDetails.OldGrowthForest == "Sí");
        _createPage.SubmitCreateForest();
        _indexPage.GoToPage();
        // Assert
        var forestTestDisplayed = _indexPage.GetForestDetails(forestTestDetails.Name);
        Assert.Multiple(() =>
        {
            Assert.That(forestTestDisplayed.Name, Is.EqualTo(forestTestDetails.Name));
            Assert.That(forestTestDisplayed.CountryOfOrigin, Is.EqualTo(forestTestDetails.CountryOfOrigin));
            Assert.That(forestTestDisplayed.TypeOfVegetation, Is.EqualTo(forestTestDetails.TypeOfVegetation));
            Assert.That(forestTestDisplayed.AreaKm2, Is.EqualTo(forestTestDetails.AreaKm2));
            Assert.That(forestTestDisplayed.OldGrowthForest, Is.EqualTo(forestTestDetails.OldGrowthForest));
        });
    }
}