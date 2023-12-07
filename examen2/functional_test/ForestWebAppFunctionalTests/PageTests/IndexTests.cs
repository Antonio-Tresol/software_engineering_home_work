using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class IndexTests
{
    private IWebDriver _driver = null!;
    private const string Url = "https://localhost:7130/";
    private IndexPage _indexPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _indexPage = new IndexPage(_driver, Url);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }
    /// <summary>
    ///    Test that the Index page layout is as expected.
    /// </summary>
    [Test]
    public void TestIndexPageLayout()
    {
        _indexPage.GoToPage();
        Assert.Multiple(() =>
        {
            Assert.That(_indexPage.IsCreateForestButtonDisplayed());
            Assert.That(_indexPage.GetForestTitle(), Is.EqualTo("Catálogo de Bosques"));
        });
    }
    /// <summary>
    ///    test that the specific forests are displayed in the index page because they are in the database
    ///    Esta prueba muestra que la operación de leer los detalles de un bosque funciona. Esto lo logra comprobando que los detalles de los bosques
    ///    que ya están en la base de datos son correctos, y que se muestran en la página de índice.
    /// </summary>
    [Test]
    public void TestSpecificForestsDisplayed()
    {
        // arrange 
        var expectedForests = new[]
        {
            new
            {
                Name = "Taiga Siberiana",
                CountryOfOrigin = "Rusia",
                TypeOfVegetation = "Taiga",
                AreaKm2 = "10000000",
                OldGrowthForest = "Sí"
            },
            new
            {
                Name = "Bosque de Fontainebleau", CountryOfOrigin = "Francia", TypeOfVegetation = "Bosque Caducifolio",
                AreaKm2 = "280", OldGrowthForest = "No"
            },
            new
            {
                Name = "Bosque de Aokigahara",
                CountryOfOrigin = "Japón",
                TypeOfVegetation = "Bosque de Coníferas",
                AreaKm2 = "35",
                OldGrowthForest = "Sí"
            }
        };
        // act
        _indexPage.GoToPage();
        // assert
        // note that multiple assertions are allowed is a way to make one assert with multiple asserts inside
        // when it fails it will show all the asserts that failed, not just the first one. It is more readable and practical than
        // making multiple tests for each assert
        Assert.Multiple(() =>
        {
            foreach (var forest in expectedForests)
            {
                //act
                // Note to the Professor: I did interleaved the act and assert to make it more readable
                var details = _indexPage.GetForestDetails(forest.Name);
                //assert
                Assert.That(details.Name, Is.EqualTo(forest.Name));
                Assert.That(details.CountryOfOrigin, Is.EqualTo(forest.CountryOfOrigin));
                Assert.That(details.TypeOfVegetation, Is.EqualTo(forest.TypeOfVegetation));
                Assert.That(details.AreaKm2, Is.EqualTo(forest.AreaKm2));
                Assert.That(details.OldGrowthForest, Is.EqualTo(forest.OldGrowthForest));
            }
        });
    }
}