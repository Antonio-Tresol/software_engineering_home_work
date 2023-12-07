using ForestWebAppFunctionalTests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForestWebAppFunctionalTests.PageTests;

[TestFixture]
public class LayoutTests
{
    private IWebDriver _driver = null!;
    private MainPage _mainPage = null!;
    private AboutPage _aboutPage = null!;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _mainPage = new MainPage(_driver, "https://localhost:7130/");
        _aboutPage = new AboutPage(_driver, "https://localhost:7130/About");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
        _driver.Quit();
    }
    /// <summary>
    ///   Test that the main page layout is as expected.
    /// </summary>
    [Test]
    public void TestMainPageLayout()
    {
        _mainPage.GoToPage();
        Assert.Multiple(() =>
        {
            Assert.That(_mainPage.IsHomeLinkDisplayed());
            Assert.That(_mainPage.IsAboutPageButtonDisplayed());
        });
    }
    /// <summary>
    ///   Test that the about page layout is as expected.
    /// </summary>
    [Test]
    public void TestAboutPageLayout()
    {
        _aboutPage.GoToPage();
        Assert.Multiple(() =>
        {
            Assert.That(_aboutPage.GetWelcomeTitle(), Is.EqualTo("¡Bienvenida a la aplicación de bosques!"));
            Assert.That(_aboutPage.GetUniversityTitle(), Is.EqualTo("Universidad de Costa Rica"));
            Assert.That(_aboutPage.GetFacultyText(), Is.EqualTo("Facultad de Ingeniería"));
            Assert.That(_aboutPage.GetSchoolText(), Is.EqualTo("Escuela de Ciencias de la Computación e Informática"));
            Assert.That(_aboutPage.GetCourseText(), Is.EqualTo("CI - 0126 Ingeniería de Software"));
            Assert.That(_aboutPage.GetExamTitle(), Is.EqualTo("Examen 2"));
            Assert.That(_aboutPage.GetProfessorName(), Is.EqualTo("Dr. Allan Berrocal Rojas"));
            Assert.That(_aboutPage.GetStudentDetails(), Is.EqualTo("A. Badilla Olivas - B80874"));
        });
    }
}