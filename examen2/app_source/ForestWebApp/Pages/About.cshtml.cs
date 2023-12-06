using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages;

/// <summary>
///     the about the app page model
/// </summary>
/// <param name="logger">a simple logger</param>
public class AboutModel(ILogger<AboutModel> logger) : PageModel
{
    public void OnGet()
    {
        // No implementation needed yet.
    }
}