﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.escuelas
{
    public class DeleteModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public DeleteModel(Universidad.Context.DB_UniversidadContext context)
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

            var escuela = await _context.Escuela.FirstOrDefaultAsync(m => m.Codigo == id);

            if (escuela == null)
            {
                return NotFound();
            }
            else 
            {
                Escuela = escuela;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Escuela == null)
            {
                return NotFound();
            }
            var escuela = await _context.Escuela.FindAsync(id);

            if (escuela != null)
            {
                Escuela = escuela;
                _context.Escuela.Remove(Escuela);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}