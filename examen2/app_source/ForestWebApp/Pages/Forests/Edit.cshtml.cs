using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForestWebApp.Pages.Forests;

public class EditModel : PageModel
{
    private readonly ForestWebAppContext _context;

    public EditModel(ForestWebAppContext context)
    {
        _context = context;
    }

    [BindProperty] public Forest Forest { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var forest = await _context.Forest.FirstOrDefaultAsync(m => m.Id == id);
        if (forest == null) return NotFound();
        Forest = forest;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Forest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ForestExists(Forest.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ForestExists(Guid id)
    {
        return _context.Forest.Any(e => e.Id == id);
    }
}