using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laboratorio4.Data;
using laboratorio4.Models;

namespace laboratorio4.Pages.Songs {
    public class CreateModel : PageModel { 
        private readonly laboratorio4.Data.laboratorio4Context _context;

        public CreateModel(laboratorio4.Data.laboratorio4Context context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
          if (!ModelState.IsValid || _context.Song == null || Song == null) {
                return Page();
            }

            _context.Song.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
