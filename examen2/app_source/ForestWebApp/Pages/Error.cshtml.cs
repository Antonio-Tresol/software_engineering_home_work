using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForestWebApp.Pages;

/// <summary>
///     the default error page model
/// </summary>
/// <param name="logger">a simple logger</param>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel(ILogger<ErrorModel> logger) : PageModel
{
    /// <summary>
    ///     The id of the current request.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    ///     Whether the request id is not null or empty.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    /// <summary>
    ///     Serves the error page with the error id or the current activity id.
    /// </summary>
    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}