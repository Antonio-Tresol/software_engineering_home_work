using Microsoft.EntityFrameworkCore; // this lines were added by the scaffolder
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data; // this lines were added by the scaffolder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
/*
 * The name of the connection string is passed in to the context by calling a method on a DbContextOptions object. 
 * For local development, the ASP.NET Core configuration system reads the connection string from the appsettings.json or the appsettings.Development.json file.
 */
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found."))); // this line was added by the scaffolder
// addDatabaseDeveloperPageExceptionFilter: This method adds a filter that intercepts any exceptions from the database and generates HTML error detail page with debugging information.
// it is used only in development environment. it provides a developer friendly error page with debugging information.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else { // this else is associated with the diagnostic package of entity framework core
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    // creating a new scope for dependency injection
    var services = scope.ServiceProvider;

    // getting the SchoolContext from the service provider
    var context = services.GetRequiredService<SchoolContext>();

    // making sure the database exists and its schema is updated
    // this is responsible for creating the database if it doesn't exist, based on the DbContext
    // we use this only in development environment, and early in the development process
    context.Database.EnsureCreated();

    // Initialize the database with any test data or seed data it requires.
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
