using ForestWebApp.Data;
using ForestWebApp.Models;
using ForestWebApp.RenderUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForestWebApp.Pages.Forests;

/// <summary>
///     The page model for the edit page of the forest app.
/// </summary>
/// <param name="forestRepository"> a repository to access forests data</param>
/// <param name="logger"> a simple logger</param>
/// <param name="countrySelectItemCreator"> a helper to create select items for countries</param>
public class EditModel(IForestRepository forestRepository, ILogger<EditModel> logger,
        ICountrySelectItemCreator countrySelectItemCreator)
    : PageModel
{
    /// <summary>
    ///     The forest to be edited.
    /// </summary>
    [BindProperty]
    public Forest Forest { get; set; } = null!;

    /// <summary>
    ///     The list of countries to be used in the select list.
    /// </summary>
    public List<SelectListItem>? Countries { get; set; }

    /// <summary>
    ///     Serves the edit page, fetching the forest data to be edited.
    /// </summary>
    /// <param name="id"> the id of the forest to be edited</param>
    /// <returns> the edit page</returns>
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        try
        {
            Countries = countrySelectItemCreator.GetCountries();
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
            logger.LogError(e, "Error in OnGetAsync in Forests/Edit.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }

    /// <summary>
    ///     Updates the forest data.
    /// </summary>
    /// <returns> the home page</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        try
        {
            await forestRepository.UpdateForestAsync(Forest);
            logger.LogInformation($"Forest {Forest.Name} updated.");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnPostAsync in Forests/Edit.cshtml.cs");
        }

        return RedirectToPage("/Index");
    }
}