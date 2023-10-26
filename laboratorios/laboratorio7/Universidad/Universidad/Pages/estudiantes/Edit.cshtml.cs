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

namespace Universidad.Pages.estudiantes
{
    public class EditModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public EditModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante =  await _context.Estudiante.FirstOrDefaultAsync(m => m.Cedula == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            Estudiante = estudiante;
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

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(Estudiante.Cedula))
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

        private bool EstudianteExists(string id)
        {
          return (_context.Estudiante?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
