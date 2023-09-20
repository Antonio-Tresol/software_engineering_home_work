using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync(){
            if (_context.Students != null)
            {
                // we could use take(x) to limit the number of records returned
                Student = await _context.Students.ToListAsync();
                // only statements that cause queries or commands to be sent to the database
                // are executed asynchrously, those are toListAsync, SingleOrDefaultAsync, FirstOrDefaultAsync and SaveChangesAsync
            }
            
        }
    }
}
