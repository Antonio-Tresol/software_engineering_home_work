using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.escuelas
{
    public class IndexModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public IndexModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        public IList<Escuela> Escuela { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Escuela != null)
            {
                Escuela = await _context.Escuela
                .Include(e => e.CodFacultadNavigation).ToListAsync();
            }
        }
    }
}
