using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

/// <summary>
///     The page model for the details page of the forest app.
/// </summary>
/// <param name="forestRepository"> a repository to access forests data</param>
/// <param name="logger"> a simple logger</param>
public class DetailsModel(IForestRepository forestRepository, ILogger<DetailsModel> logger)
    : PageModel
{
    /// <summary>
    ///     The forest to be displayed.
    /// </summary>
    public Forest Forest { get; set; } = null!;

    /// <summary>
    ///     Serves the details page, fetching the forest data to be displayed.
    /// </summary>
    /// <param name="id"> the id of the forest to be displayed</param>
    /// <returns> the details page</returns>
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        try
        {
            var forest = await forestRepository.GetForestAsync(id);
            if (forest == null)
            {
                logger.LogWarning($"Forest {id} not found.");
                return NotFound();
            }

            Forest = forest;
            return Page();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnGetAsync in Forests/Details.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }
}