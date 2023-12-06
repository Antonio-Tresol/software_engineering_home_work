using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages;

/// <summary>
///     The page model for the home page of the forest app.
/// </summary>
/// <param name="forestRepository"> a repository to access forests data</param>
/// <param name="logger">a simple logger</param>
public class IndexModel(IForestRepository forestRepository, ILogger<IndexModel> logger)
    : PageModel
{
    /// <summary>
    ///     The list of forests to be displayed.
    /// </summary>
    public IList<Forest> Forests { get; set; } = null!;

    /// <summary>
    ///     Serves the home page, fetching all the forest data available.
    /// </summary>
    public async Task OnGetAsync()
    {
        try
        {
            var result = await forestRepository.GetForestsAsync();
            Forests = result.ToList();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnGetAsync in Forests/Index.cshtml.cs");
        }
    }
}