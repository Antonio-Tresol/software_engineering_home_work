using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.empadronados
{
    public class CreateModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public CreateModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CedEstudiante"] = new SelectList(_context.Estudiante, "Cedula", "Cedula");
        ViewData["CodCarrera"] = new SelectList(_context.Carrera, "Codigo", "Codigo");
            return Page();
        }

        [BindProperty]
        public Empadronado_en Empadronado_en { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Empadronado_en == null || Empadronado_en == null)
            {
                return Page();
            }

            _context.Empadronado_en.Add(Empadronado_en);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
