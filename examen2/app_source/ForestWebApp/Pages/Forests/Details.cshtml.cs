using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

public class DetailsModel(IForestRepository forestRepository, ILogger<DetailsModel> logger)
    : PageModel
{
    public Forest Forest { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        try
        {
            var forest = await forestRepository.GetForestAsync(id);
            if (forest == null)
            {
                logger.LogWarning($"Forest {Forest.Name} not found.");
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