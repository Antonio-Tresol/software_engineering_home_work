using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.estudiantes
{
    public class DetailsModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DetailsModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

      public Estudiante Estudiante { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Cedula == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudiante = estudiante;
            }
            return Page();
        }
    }
}
