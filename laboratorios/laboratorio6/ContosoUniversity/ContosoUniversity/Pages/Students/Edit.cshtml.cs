using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students {
    public class EditModel : PageModel {
        private readonly SchoolContext _context;

        public EditModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            var studentToUpdate = await _context.Students.FindAsync(id);

            if (studentToUpdate == null) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "student",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                // The database context keeps track of whether entities in memory are in sync with their corresponding rows in the database.
                // This tracking information determines what happens when SaveChangesAsync is called. In a nustshell, the database context issues and  insert command when the state is "Added",
                // an update command when the state is "Modified", and a delete command when the state is "Deleted".
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
