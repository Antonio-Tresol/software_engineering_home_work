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
    public class IndexModel : PageModel {
        private readonly laboratorio4Context _context;

        public IndexModel(laboratorio4Context context) {
            _context = context;
        }

        public IList<Song> Song { get;set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Song != null) {
                Song = await _context.Song.ToListAsync();
            }
        }
    }
}
