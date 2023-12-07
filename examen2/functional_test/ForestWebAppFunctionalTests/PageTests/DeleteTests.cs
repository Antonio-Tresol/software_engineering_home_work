using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class DeleteTests
{
    private IWebDriver _driver = null!;
    private const string Url = "https://localhost:7130/Forests/Delete?id=";
    private const string ForestId = "F5B97F96-D133-44A6-DF06-08DBF7103086";
    private const string ForestName = "Bosque Nuboso Monteverde";
    private DeletePage _deletePage = null!;
    private IndexPage _indexPage = null!;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _deletePage = new DeletePage(_driver, ForestName, ForestId, Url);
        _indexPage = new IndexPage(_driver, "https://localhost:7130/");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }

    /// <summary>
    ///     Test that the Delete operation works as expected by deleting a forest and checking that it is no longer
    ///     displayed in the index page.
    ///     IMPORTANT! This test will fail if the forest to be deleted is not present in the database or after it is deleted
    ///     successfully once, as it will not be present in the database anymore.
    ///     Este test prueba la funcionalidad pues entra en la página de eliminar un bosque, comprueba que los detalles del bosque
    ///     son correctos, lo elimina y comprueba que ya no está en la página de índice. Así se comprueba que la operación de eliminar.
    /// </summary>
    [Test]
    public void TestDeleteForest()
    {
        // Arrange
        var forestTestDetails = new
        {
            Name = "Bosque Nuboso Monteverde", CountryOfOrigin = "Costa Rica", TypeOfVegetation = "Bosque Nuboso",
            AreaKm2 = "105",
            OldGrowthForest = "Sí"
        };
        // act
        _deletePage.GoToPage();
        var name = "Eliminar Bosque: " + forestTestDetails.Name;
        // assert to check that the forest details are correct, I'm doing two asserts and two acts because there is only one
        // test forest to be deleted in the data initializer and as there isn't any order in which the tests are run, I need
        // to check that the forest details are correct before deleting it.
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(_deletePage.GetForestName(), Is.EqualTo(name));
            Assert.That(_deletePage.GetCountryOfOrigin(), Is.EqualTo(forestTestDetails.CountryOfOrigin));
            Assert.That(_deletePage.GetTypeOfVegetation(), Is.EqualTo(forestTestDetails.TypeOfVegetation));
            Assert.That(_deletePage.GetAreaKm2(), Is.EqualTo(forestTestDetails.AreaKm2));
            Assert.That(_deletePage.GetOldGrowthForestStatus(), Is.EqualTo(forestTestDetails.OldGrowthForest));
        });

        // Act
        _deletePage.ClickDeleteForestSubmitButton();
        _indexPage.GoToPage();

        // Assert to check that the forest was deleted
        try
        {
            _indexPage.GetForestDetails(forestTestDetails.Name);
            Assert.Fail("Forest was not deleted");
        }
        catch (WebDriverTimeoutException e)
        {
            Assert.Pass("Forest was deleted");
        }
    }
}