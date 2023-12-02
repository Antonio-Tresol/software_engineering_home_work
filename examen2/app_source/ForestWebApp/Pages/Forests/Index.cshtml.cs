using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ForestWebApp.Data;
using ForestWebApp.Models;

namespace ForestWebApp.Pages.Forests;

public class IndexModel : PageModel
{
    private readonly ForestWebAppContext _context;

    public IndexModel(ForestWebAppContext context)
    {
        _context = context;
    }

    public IList<Forest> Forest { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Forest = await _context.Forest.ToListAsync();
    }
}