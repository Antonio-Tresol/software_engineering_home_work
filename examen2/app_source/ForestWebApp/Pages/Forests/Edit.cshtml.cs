using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

public class EditModel(IForestRepository forestRepository, ILogger<EditModel> logger)
    : PageModel
{
    [BindProperty] public Forest Forest { get; set; }

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
            logger.LogError(e, "Error in OnGetAsync in Forests/Edit.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }


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

        return RedirectToPage("./Index");
    }
}