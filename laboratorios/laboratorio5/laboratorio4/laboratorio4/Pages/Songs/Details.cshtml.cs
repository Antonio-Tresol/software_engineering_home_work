using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laboratorio4.Data;
using laboratorio4.Models;

namespace laboratorio4.Pages.Songs {
    public class DetailsModel : PageModel {
        private readonly laboratorio4.Data.laboratorio4Context _context;

        public DetailsModel(laboratorio4.Data.laboratorio4Context context) {
            _context = context;
        }

      public Song Song { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Song == null) {
                return NotFound();
            }

            var song = await _context.Song.FirstOrDefaultAsync(m => m.Id == id);
            if (song == null) {
                return NotFound();
            } else {
                Song = song;
            }
            return Page();
        }
    }
}
