using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.ViewModels;

namespace ContosoUniversity.Pages.Students {
    public class CreateModel : PageModel {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }
        // we are using the viewmodel class to create a new student, this protects us from overposting attacks because we are only binding the fields we want to update.
        // using the bind property attribute, we can bind the properties of the StudentVM class to the page model.
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        //    [BindProperty]
        //    public Student Student { get; set; }

        //    public async Task<IActionResult> OnPostAsync() {
        //        var emptyStudent = new Student();
        //        // we use this so that we only bind the fields we want to update.
        //        if (await TryUpdateModelAsync(
        //            emptyStudent,
        //            "student",   // Prefix for form value.
        //            s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
        //        {
        //            _context.Students.Add(emptyStudent);
        //            await _context.SaveChangesAsync();
        //            return RedirectToPage("./Index");
        //        }

        //        return Page();
        //    }
        //
    }
}
