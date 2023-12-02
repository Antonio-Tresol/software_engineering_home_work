using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages.Forests;

public class CreateModel : PageModel
{
    private readonly ForestWebAppContext _context;

    public CreateModel(ForestWebAppContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty] public Forest Forest { get; set; } = default!;

  
    public async Task<IActionResult> OnPostAsync()
    {
        var forest = new Forest();

        if (!await TryUpdateModelAsync(
                forest,
                "forest",
                f => f.Name, 
                f => f.CountryOfOrigin, 
                f => f.AreaKm2, 
                f => f.TypeOfVegetation, 
                f => f.OldGrowthForest)
            )
            return RedirectToPage("./Index");
        
        _context.Forest.Add(forest);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}