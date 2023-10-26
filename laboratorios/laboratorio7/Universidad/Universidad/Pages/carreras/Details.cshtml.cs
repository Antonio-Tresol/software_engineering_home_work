using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.carreras
{
    public class DetailsModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DetailsModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

      public Carrera Carrera { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Carrera == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera.FirstOrDefaultAsync(m => m.Codigo == id);
            if (carrera == null)
            {
                return NotFound();
            }
            else 
            {
                Carrera = carrera;
            }
            return Page();
        }
    }
}
