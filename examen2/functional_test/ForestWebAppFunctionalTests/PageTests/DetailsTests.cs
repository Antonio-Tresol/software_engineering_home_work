using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class DetailsTests
{
    private static readonly string url = "https://localhost:7130/Forests/Details?id=";
    private static readonly string forestId = "FFCC82F7-100D-4169-DF05-08DBF7103086";
    private static readonly string forestName = "Bosque de Fontainebleau";
    private IWebDriver _driver = null!;
    private DetailsPage _detailsPage = null!;


    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _detailsPage = new DetailsPage(_driver, forestName, forestId, url);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }
    /// <summary>
    ///   Test that the details page layout is as expected, based on the given forest id already in the database.
    ///   Este test prueba que la página de detalles tiene el layout esperado, basado en el id del bosque que ya está en la base de datos.
    ///   Ademas, comprueba que los detalles del bosque son correctos. Así se comprueba que la operación de leer los detalles de un bosque funciona.
    /// </summary>
    [Test]
    public void TestDetailsPageLayout()
    {
        // Arrange
        var forest = new
        {
            Name = "Bosque de Fontainebleau",
            CountryOfOrigin = "Francia",
            TypeOfVegetation = "Bosque Caducifolio",
            AreaKm2 = "280",
            OldGrowthForest = "No"
        };
        // Act
        _detailsPage.GoToPage();
        // Assert
        var name = "Detalles del Bosque: " + forest.Name;
        Assert.Multiple(() =>
        {
            Assert.That(_detailsPage.GetForestName(), Is.EqualTo(name));
            Assert.That(_detailsPage.GetCountryOfOrigin(), Is.EqualTo(forest.CountryOfOrigin));
            Assert.That(_detailsPage.GetTypeOfVegetation(), Is.EqualTo(forest.TypeOfVegetation));
            Assert.That(_detailsPage.GetAreaKm2(), Is.EqualTo(forest.AreaKm2));
            Assert.That(_detailsPage.GetOldGrowthForestStatus(), Is.EqualTo(forest.OldGrowthForest));
        });
    }
}