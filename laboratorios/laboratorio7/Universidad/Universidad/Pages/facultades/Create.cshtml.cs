using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.facultades
{
    public class CreateModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public CreateModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Facultad Facultad { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Facultad == null || Facultad == null)
            {
                return Page();
            }

            _context.Facultad.Add(Facultad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
