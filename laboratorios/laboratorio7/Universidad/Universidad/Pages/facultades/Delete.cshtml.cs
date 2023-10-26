using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.facultades
{
    public class DeleteModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DeleteModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Facultad Facultad { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Facultad == null)
            {
                return NotFound();
            }

            var facultad = await _context.Facultad.FirstOrDefaultAsync(m => m.Codigo == id);

            if (facultad == null)
            {
                return NotFound();
            }
            else 
            {
                Facultad = facultad;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Facultad == null)
            {
                return NotFound();
            }
            var facultad = await _context.Facultad.FindAsync(id);

            if (facultad != null)
            {
                Facultad = facultad;
                _context.Facultad.Remove(Facultad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
