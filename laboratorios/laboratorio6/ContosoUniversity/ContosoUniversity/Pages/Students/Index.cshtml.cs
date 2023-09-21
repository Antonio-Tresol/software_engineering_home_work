using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.Extensions.Configuration;
using ContosoUniversity.Utils;

namespace ContosoUniversity.Pages.Students {
    public class IndexModel : PageModel {
        private readonly SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // These three strings are used to determine how to sort the Student list
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        // This is the list of students that will be displayed in the view
        public PaginatedList<Student> Students { get; set; }



        // This method gets called when the page is requested
        public async Task OnGetAsync(string sortOrder,
          string currentFilter, string searchString, int? pageIndex) {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            // Get the list of all students
            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s; // this is a query using LINQ syntax
            if (!string.IsNullOrEmpty(searchString)) { // here we are using a lambda expression to filter the list using the search string
                // our search string will filter the list by first name or last name
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
                //  contains function on Inumerable  is .Net core implementation(is case sensitive), contains called on IQueryable is database implementation,
                //  so it is case sensitive or not depending on the database
                // to make them explicitly case sensitive use the following
                // Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()) it has performance implications, it will be slower, shouldn't be used on large datasets
            }
            // Determine the sorting order
            studentsIQ = sortOrder switch {
                "name_desc" => studentsIQ.OrderByDescending(s => s.LastName),
                "Date" => studentsIQ.OrderBy(s => s.EnrollmentDate),
                "date_desc" => studentsIQ.OrderByDescending(s => s.EnrollmentDate),
                _ => studentsIQ.OrderBy(s => s.LastName),
            };

            var pageSize = Configuration.GetValue("PageSize", 4);
            Students = await PaginatedList<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
// we could use take(x) to limit the number of records returned
// Student = await _context.Students.ToListAsync();
// only statements that cause queries or commands to be sent to the database
// are executed asynchrously, those are toListAsync, SingleOrDefaultAsync, FirstOrDefaultAsync and SaveChangesAsync