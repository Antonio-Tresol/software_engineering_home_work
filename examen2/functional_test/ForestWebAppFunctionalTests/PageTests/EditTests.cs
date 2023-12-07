using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class EditTests
{
    private IWebDriver _driver = null!;
    private EditPage _editPage = null!;
    private static readonly string url = "https://localhost:7130/Forests/Edit?id=";
    private static readonly string forestId = "2A9D2B53-82DF-4F10-DF04-08DBF7103086";
    private IndexPage _indexPage = null!;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _editPage = new EditPage(_driver, forestId, url);
        _indexPage = new IndexPage(_driver, "https://localhost:7130/");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }

    /// <summary>
    ///     Test that the Edit operation works as expected by editing a forest and checking that the changes are displayed
    ///     displayed in the index page.
    ///     Esta prueba prueba la funcionalidad pues entra en la página de editar un bosque, edita los detalles del bosque,
    ///     y comprueba que los detalles del bosque son correctos posteriormente en la página de index. Así se comprueba que la operación de editar un bosque funciona.
    /// </summary>
    [Test]
    public void TestEditForest()
    {
        // Arrange
        var newForest = new
        {
            Name = "Amazonia",
            CountryOfOrigin = "Brasil",
            TypeOfVegetation = "Selva Tropical lluviosa",
            AreaKm2 = "5500002",
            OldGrowthForest = "Sí"
        };
        // Act
        _editPage.GoToPage();
        _editPage.EnterForestName(newForest.Name);
        _editPage.SelectCountryOfOrigin(newForest.CountryOfOrigin);
        _editPage.EnterTypeOfVegetation(newForest.TypeOfVegetation);
        _editPage.EnterAreaKm2(newForest.AreaKm2);
        _editPage.SetOldGrowthForest(true);
        _editPage.SubmitEditForest();

        _indexPage.GoToPage();

        // Assert
        var forestDetailsDisplayed = _indexPage.GetForestDetails(newForest.Name);

        Assert.Multiple(() =>
        {
            Assert.That(forestDetailsDisplayed.Name, Is.EqualTo(newForest.Name));
            Assert.That(forestDetailsDisplayed.CountryOfOrigin, Is.EqualTo(newForest.CountryOfOrigin));
            Assert.That(forestDetailsDisplayed.TypeOfVegetation, Is.EqualTo(newForest.TypeOfVegetation));
            Assert.That(forestDetailsDisplayed.AreaKm2, Is.EqualTo(newForest.AreaKm2));
            Assert.That(forestDetailsDisplayed.OldGrowthForest, Is.EqualTo(newForest.OldGrowthForest));
        });
    }
}