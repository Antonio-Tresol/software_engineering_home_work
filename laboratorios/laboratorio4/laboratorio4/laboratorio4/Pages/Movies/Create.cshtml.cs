using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laboratorio4.Data;
using laboratorio4.Models;

namespace laboratorio4.Pages.Movies {
    public class CreateModel : PageModel {
        private readonly laboratorio4Context _context;

        public CreateModel(laboratorio4Context context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page(); // renders create.cshtml
        }

        [BindProperty] // use for movie to opt in model binding. That means that when a posts forms comes they are 
        // bind in runtime to the model values.
        public Movie Movie { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // here we must return because of the type of functions
        /* In the context of .NET, asynchronous code is code that does not block the calling thread while it is executing. 
         * This means that the calling thread can continue to do other work while the asynchronous code is running.
         * Asynchronous code is typically used for tasks that take a long time to complete, 
         * such as reading from a file or making a network request. By using asynchronous code,
         * you can prevent the calling thread from being blocked and make your application more responsive
         */
        public async Task<IActionResult> OnPostAsync() { // runs when posts comes from page
            if (!ModelState.IsValid || _context.Movie == null || Movie == null) { // if there are any errors the form is redesplays
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
