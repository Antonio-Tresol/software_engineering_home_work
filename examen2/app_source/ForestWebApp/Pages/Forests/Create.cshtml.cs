using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

public class CreateModel(IForestRepository forestRepository, ILogger<CreateModel> logger)
    : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty] public Forest Forest { get; set; }


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
        

        return RedirectToPage("./Index");
    }

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