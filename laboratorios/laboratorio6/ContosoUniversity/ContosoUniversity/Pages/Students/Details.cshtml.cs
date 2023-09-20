using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students {
    public class DetailsModel : PageModel {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context) {
            _context = context;
        }

      public Student Student { get; set; }

        // This method handles the asynchronous get request for a student's details.
        // The parameter 'id' is the unique identifier for the desired student.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Check if a valid student id was provided and if the student collection has been populated by the database.
            if (id == null || _context.Students == null)
            {
                // If either of the criteria is not met, return a "not found" result.
                return NotFound();
            }

            // Use entity framework to retrieve the desired student from the database, along with their enrollment and course details.
            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id); // here we use first or default because we are only looking for one student, and we dont want to throw an error if there are multiple students with the same id.
            // also we are not using findAsync because with findAsync, we cannot use include method. the include method can be use with firstordefault method and it is useful when we want to include related data.

            // If the desired student is not found, return a "not found" result. Otherwise, set the student property to the retrieved student.
            if (Student == null)
            {
                return NotFound();
            }
            else
            {
                Student = Student;
            }

            // Return the view associated with this page containing the details of the student.
            return Page();
        }
    }
}
