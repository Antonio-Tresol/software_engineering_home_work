using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.cursos
{
    public class DeleteModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DeleteModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Curso Curso { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FirstOrDefaultAsync(m => m.Sigla == id);

            if (curso == null)
            {
                return NotFound();
            }
            else 
            {
                Curso = curso;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);

            if (curso != null)
            {
                Curso = curso;
                _context.Curso.Remove(Curso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
