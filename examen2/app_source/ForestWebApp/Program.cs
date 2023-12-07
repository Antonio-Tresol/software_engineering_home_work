using ForestWebApp.Data;
using ForestWebApp.RenderUtils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IForestRepository, ForestRepository>();
builder.Services.AddSingleton<ICountrySelectItemCreator, CountrySelectItemCreator>();
builder.Services.AddLogging();

builder.Services.AddDbContext<ForestWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForestWebAppContext") ?? throw new InvalidOperationException("Connection string 'ForestWebAppContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ForestWebAppContext>();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    ForestDataInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
