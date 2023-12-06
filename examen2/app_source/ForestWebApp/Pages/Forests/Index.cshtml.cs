using Microsoft.AspNetCore.Mvc.RazorPages;
using ForestWebApp.Data;
using ForestWebApp.Models;

namespace ForestWebApp.Pages.Forests;

public class IndexModel(IForestRepository forestRepository, ILogger<IndexModel> logger)
    : PageModel
{
    public IList<Forest>? Forest { get; set; }

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