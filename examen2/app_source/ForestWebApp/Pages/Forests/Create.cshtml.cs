using ForestWebApp.Data;
using ForestWebApp.Models;
using ForestWebApp.RenderUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForestWebApp.Pages.Forests;
/// <summary>
///   The page model for the create page of the forest app.
/// </summary>
/// <param name="forestRepository"> a repository to access forests data</param>
/// <param name="logger"> a simple logger</param>
/// <param name="countrySelectItemCreator"> a helper to create select items for countries</param>
public class CreateModel(IForestRepository forestRepository, ILogger<CreateModel> logger,
        ICountrySelectItemCreator countrySelectItemCreator)
    : PageModel
{
    /// <summary>
    ///  The forest to be created.
    /// </summary>
    [BindProperty] public Forest Forest { get; set; } = null!;
    /// <summary>
    ///   The list of countries to be used in the select list.
    /// </summary>
    public List<SelectListItem>? Countries { get; set; }
    /// <summary>
    ///  Serves the create page.
    /// </summary>
    /// <returns> the create page</returns>
    public IActionResult OnGet()
    {
        Countries = countrySelectItemCreator.GetCountries();
        return Page();
    }
    /// <summary>
    ///   Adds the forest data.
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> OnPostAsync()
    {
        var forest = new Forest();

        if (!await TryUpdateModelAsync(forest))
            return RedirectToPage("./Index");
        try
        {
            await forestRepository.AddForestAsync(forest);
            logger.LogInformation($"Forest {Forest.Name} added.");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnPostAsync in Forests/Create.cshtml.cs");
        }


        return RedirectToPage("/Index");
    }
    /// <summary>
    ///  Tries to update the model with the posted data.
    /// </summary>
    /// <param name="forest"> the forest to be updated</param>
    /// <returns> true if the model can be updated successfully, false otherwise</returns>
    private Task<bool> TryUpdateModelAsync(Forest forest)
    {
        return TryUpdateModelAsync(
            forest,
            "forest",
            f => f.Name,
            f => f.CountryOfOrigin,
            f => f.AreaKm2,
            f => f.TypeOfVegetation,
            f => f.OldGrowthForest);
    }
}