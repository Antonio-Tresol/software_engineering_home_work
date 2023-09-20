using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students {
    public class DeleteModel : PageModel
    {
        private readonly Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        // Constructor with parameters 
        public DeleteModel(Data.SchoolContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; }
        public string ErrorMessage { get; set; }

        // GET public method. It's called when the HTTP GET request is sent to retrieve the page. If there's an ID, it returns the Student with that ID.
        // AsNoTracking() is used to improve performance and avoid concurrency issues.
        // Returns NotFound() when the ID does not exist, and a page otherwise.
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false) {
            if (id == null) { // if there's no ID
                return NotFound(); // Returns NotFound()
            }

            Student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id); // Looks for the Student that matches the ID

            if (Student == null) { // If there's no student, return NotFound()
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault()) { // If there's a saveChangesError
                ErrorMessage = string.Format("Delete {ID} failed. Try again", id); // sets ErrorMessage to the error message. 
            }

            return Page(); // Returns the page normally
        }

        // POST public method. Called when the form is submitted. It deletes the Student with the specified ID.
        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) { // If there's no ID return NotFound()
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id); // Looks for the Student object

            if (student == null) { // If there's no student. Return NotFound()
                return NotFound();
            }

            try { // Try to remove and save the changes
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index"); // go to the student list page
            } catch (DbUpdateException ex)  { // if there's any exception during saveChangesAsync, logs the exception with the error message and the exception itself and redirects to Delete page.
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}