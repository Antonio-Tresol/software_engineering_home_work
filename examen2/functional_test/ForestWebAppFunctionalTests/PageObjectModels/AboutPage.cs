using OpenQA.Selenium;

namespace ForestWebAppFunctionalTests.PageObjectModels;

/// <summary>
///     a page object model for the about page of the Forest Web App.
/// </summary>
/// <param name="driver">The WebDriver instance used for browser interactions.</param>
/// <param name="url">The URL of the About page.</param>
public class AboutPage(IWebDriver driver, string url) : BasePage(driver, url)
{
    /// <summary>
    ///     the elements on the About page
    /// </summary>
    private static By WelcomeTitle => By.CssSelector("h2.display-4");

    private static By UniversityTitle => By.Id("UCR");
    private static By FacultyText => By.Id("Facultad");
    private static By SchoolText => By.Id("Escuela");
    private static By CourseText => By.Id("Curso");
    private static By ExamTitle => By.Id("Examen");
    private static By ProfessorName => By.Id("NombreProfesor");
    private static By StudentDetails => By.Id("DatosEstudiante");

    /// <summary>
    ///     Gets the welcome title text from the About page.
    /// </summary>
    /// <returns>The welcome title text.</returns>
    public string? GetWelcomeTitle()
    {
        return GetText(WelcomeTitle);
    }

    /// <summary>
    ///     Gets the university title text from the About page.
    /// </summary>
    /// <returns>The university title text.</returns>
    public string? GetUniversityTitle()
    {
        return GetText(UniversityTitle);
    }

    /// <summary>
    ///     Gets the faculty text from the About page.
    /// </summary>
    /// <returns>The faculty text.</returns>
    public string? GetFacultyText()
    {
        return GetText(FacultyText);
    }

    /// <summary>
    ///     Gets the school text from the About page.
    /// </summary>
    /// <returns>The school text.</returns>
    public string? GetSchoolText()
    {
        return GetText(SchoolText);
    }

    /// <summary>
    ///     Gets the course text from the About page.
    /// </summary>
    /// <returns>The course text.</returns>
    public string? GetCourseText()
    {
        return GetText(CourseText);
    }

    /// <summary>
    ///     Gets the exam title text from the About page.
    /// </summary>
    /// <returns>The exam title text.</returns>
    public string? GetExamTitle()
    {
        return GetText(ExamTitle);
    }

    /// <summary>
    ///     Gets the professor name text from the About page.
    /// </summary>
    /// <returns>The professor name text.</returns>
    public string? GetProfessorName()
    {
        return GetText(ProfessorName);
    }

    /// <summary>
    ///     Gets the student details text from the About page.
    /// </summary>
    /// <returns>The student details text.</returns>
    public string? GetStudentDetails()
    {
        return GetText(StudentDetails);
    }
}