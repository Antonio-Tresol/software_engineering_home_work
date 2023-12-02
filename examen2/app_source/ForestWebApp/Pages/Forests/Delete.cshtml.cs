using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForestWebApp.Pages.Forests;

public class DeleteModel : PageModel
{
    private readonly ForestWebAppContext _context;

    public DeleteModel(ForestWebAppContext context)
    {
        _context = context;
    }

    [BindProperty] public Forest Forest { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var forest = await _context.Forest.FirstOrDefaultAsync(m => m.Id == id);

        if (forest == null)
            return NotFound();
        Forest = forest;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var forest = await _context.Forest.FindAsync(id);
        if (forest != null)
        {
            Forest = forest;
            _context.Forest.Remove(Forest);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}