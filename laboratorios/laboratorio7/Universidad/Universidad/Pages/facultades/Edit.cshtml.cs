using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.facultades
{
    public class EditModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public EditModel(Universidad.Context.DB_UniversidadContext context)
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

            var facultad =  await _context.Facultad.FirstOrDefaultAsync(m => m.Codigo == id);
            if (facultad == null)
            {
                return NotFound();
            }
            Facultad = facultad;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Facultad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadExists(Facultad.Codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacultadExists(string id)
        {
          return (_context.Facultad?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
