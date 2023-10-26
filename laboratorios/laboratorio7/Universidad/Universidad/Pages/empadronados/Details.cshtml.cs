using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.empadronados
{
    public class DetailsModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DetailsModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

      public Empadronado_en Empadronado_en { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Empadronado_en == null)
            {
                return NotFound();
            }

            var empadronado_en = await _context.Empadronado_en.FirstOrDefaultAsync(m => m.CedEstudiante == id);
            if (empadronado_en == null)
            {
                return NotFound();
            }
            else 
            {
                Empadronado_en = empadronado_en;
            }
            return Page();
        }
    }
}
