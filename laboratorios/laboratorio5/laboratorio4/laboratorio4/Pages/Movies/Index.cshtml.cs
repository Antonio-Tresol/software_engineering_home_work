using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laboratorio4.Data;
using laboratorio4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync() {
            // The following code is a LINQ query that retrieves all the genres from the database.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            // this is a LINQ query that retrieves all the movies from the database.
            var movies = from m in _context.Movie
                         select m;
        
            if (!string.IsNullOrEmpty(SearchString)) {
                // The LINQ query uses the Where method to select movies that contain the search string.s
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre)) {
                // The LINQ query uses the Where method to select movies that match the selected genre.
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            // then the query is executed and the results are stored in the Movie property and the Genres property is initialized with a SelectList containing genres from the database.
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
