using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForestWebApp.Pages.Forests;

public class DeleteModel(IForestRepository forestRepository, ILogger<DeleteModel> logger)
    : PageModel
{
    [BindProperty] public Forest Forest { get; set; }

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

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        try
        {
            var forest = await forestRepository.GetForestAsync(id);
            if (forest == null)
                return NotFound();

            await forestRepository.DeleteForestAsync(forest);
            return RedirectToPage("./Index");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnPostAsync in Forests/Delete.cshtml.cs");
            return RedirectToPage("../Error");
        }
    }
}