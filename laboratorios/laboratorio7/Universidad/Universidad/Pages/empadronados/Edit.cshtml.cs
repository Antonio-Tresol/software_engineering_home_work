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

namespace Universidad.Pages.empadronados
{
    public class EditModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public EditModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empadronado_en Empadronado_en { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Empadronado_en == null)
            {
                return NotFound();
            }

            var empadronado_en =  await _context.Empadronado_en.FirstOrDefaultAsync(m => m.CedEstudiante == id);
            if (empadronado_en == null)
            {
                return NotFound();
            }
            Empadronado_en = empadronado_en;
           ViewData["CedEstudiante"] = new SelectList(_context.Estudiante, "Cedula", "Cedula");
           ViewData["CodCarrera"] = new SelectList(_context.Carrera, "Codigo", "Codigo");
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

            _context.Attach(Empadronado_en).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Empadronado_enExists(Empadronado_en.CedEstudiante))
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

        private bool Empadronado_enExists(string id)
        {
          return (_context.Empadronado_en?.Any(e => e.CedEstudiante == id)).GetValueOrDefault();
        }
    }
}
