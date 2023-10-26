using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Context;
using Universidad.Models;

namespace Universidad.Pages.empadronados
{
    public class IndexModel : PageModel
    {
        private readonly Universidad.Context.DB_UniversidadContext _context;

        public IndexModel(Universidad.Context.DB_UniversidadContext context)
        {
            _context = context;
        }

        public IList<Empadronado_en> Empadronado_en { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empadronado_en != null)
            {
                Empadronado_en = await _context.Empadronado_en
                .Include(e => e.CedEstudianteNavigation)
                .Include(e => e.CodCarreraNavigation).ToListAsync();
            }
        }
    }
}
