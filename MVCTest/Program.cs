using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MVCTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCTestContext") ?? throw new InvalidOperationException("Connection string 'MVCTestContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DBInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
