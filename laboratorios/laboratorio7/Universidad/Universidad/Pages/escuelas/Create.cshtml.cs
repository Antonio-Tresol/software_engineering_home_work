using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.escuelas
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
        ViewData["CodFacultad"] = new SelectList(_context.Facultad, "Codigo", "Codigo");
            return Page();
        }

        [BindProperty]
        public Escuela Escuela { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Escuela == null || Escuela == null)
            {
                return Page();
            }

            _context.Escuela.Add(Escuela);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
