using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

/// <summary>
///     The page model for the delete page of the forest app.
/// </summary>
/// <param name="forestRepository"> a repository to access forests data</param>
/// <param name="logger"> a simple logger</param>
public class DeleteModel(IForestRepository forestRepository, ILogger<DeleteModel> logger)
    : PageModel
{
    /// <summary>
    ///     The forest to be deleted.
    /// </summary>
    [BindProperty]
    public Forest Forest { get; set; } = null!;

    /// <summary>
    ///     Serves the delete page, fetching the forest data to be deleted.
    /// </summary>
    /// <param name="id"> the id of the forest to be deleted</param>
    /// <returns> the delete page</returns>
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        try
        {
            var forest = await forestRepository.GetForestAsync(id);

            if (forest == null)
                return NotFound();
            Forest = forest;
            return Page();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnGetAsync in Forests/Delete.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }

    /// <summary>
    ///     Deletes the forest data.
    /// </summary>
    /// <param name="id"> the id of the forest to be deleted</param>
    /// <returns> the home page</returns>
    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        try
        {
            var forest = await forestRepository.GetForestAsync(id);
            if (forest == null)
                return NotFound();

            await forestRepository.DeleteForestAsync(forest);
            return RedirectToPage("/Index");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnPostAsync in Forests/Delete.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }
}