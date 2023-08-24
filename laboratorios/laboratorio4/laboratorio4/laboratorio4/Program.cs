using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using laboratorio4.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// see here that first we prepare the builder and the before building our app
// we can do "dependency injection" to it, so we can easily add more functionality.
/* Dependency injection (DI) is a programming technique in which an object or function receives other objects or 
 * functions (called dependencies) that it needs to perform its task, rather than creating them itself. 
 * This inversion of control (IoC) decouples the object or function from its dependencies and makes it easier to test and maintain. 
 */
builder.Services.AddRazorPages();
builder.Services.AddDbContext<laboratorio4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("laboratorio4Context") ?? throw new InvalidOperationException("Connection string 'laboratorio4Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Redirect HTTP requests to HTTPS for secure communication.
app.UseHttpsRedirection();

// Serve static files (like images, CSS, JavaScript) from the "wwwroot" directory.
app.UseStaticFiles();

// Set up routing based on URL paths.
app.UseRouting();

// Apply authorization policies to incoming requests.
app.UseAuthorization();

// Map Razor Pages endpoints to handle incoming requests.
app.MapRazorPages();

// Start processing incoming HTTP requests.
app.Run();
