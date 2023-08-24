using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laboratorio4.Data;
using laboratorio4.Models;

namespace laboratorio4.Pages.Movies {
    public class IndexModel : PageModel {
        private readonly laboratorio4Context _context;
        // constructor uses dependecy injection to add the context
        public IndexModel(laboratorio4Context context) {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        // on get executes when the get request is made in the page
        // When OnGet returns void or OnGetAsync returns Task, no return statement is used. 
        public async Task OnGetAsync() {
            if (_context.Movie != null) {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
