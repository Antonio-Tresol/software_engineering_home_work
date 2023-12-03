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

public class IndexModel(IForestRepository forestRepository, ILogger<IndexModel> logger)
    : PageModel
{
    public IList<Forest> Forest { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
         var result = await forestRepository.GetForestsAsync();
                 Forest = result.ToList();   
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in OnGetAsync in Forests/Index.cshtml.cs");
        }
    }
}