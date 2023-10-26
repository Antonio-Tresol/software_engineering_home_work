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

namespace Universidad.Pages.escuelas
{
    public class EditModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public EditModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Escuela Escuela { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Escuela == null)
            {
                return NotFound();
            }

            var escuela =  await _context.Escuela.FirstOrDefaultAsync(m => m.Codigo == id);
            if (escuela == null)
            {
                return NotFound();
            }
            Escuela = escuela;
           ViewData["CodFacultad"] = new SelectList(_context.Facultad, "Codigo", "Codigo");
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

            _context.Attach(Escuela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscuelaExists(Escuela.Codigo))
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

        private bool EscuelaExists(string id)
        {
          return (_context.Escuela?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
