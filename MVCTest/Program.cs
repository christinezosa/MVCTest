using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("CheckExists");
var dbConnString = builder.Configuration.GetConnectionString("MVCTestContext");
var databaseName = "MVCTestContext-9682b5ae-3fa3-4b3c-a2f9-80cdcb5b6484";

// Check if database exists in the computer. If it does not, create the database
SqlConnection conn = new SqlConnection(connString);
var command = new SqlCommand($"SELECT db_id('" + databaseName + "')", conn);

conn.Open();

if (command.ExecuteScalar() == DBNull.Value)
{
    var createCommand = new SqlCommand($"CREATE DATABASE [" + databaseName + "]", conn);
    createCommand.ExecuteNonQuery();
}

if (conn.State == ConnectionState.Open)
{
    conn.Close();
}

builder.Services.AddDbContext<MVCTestContext>(options =>
    options.UseSqlServer(dbConnString ?? throw new InvalidOperationException("Connection string 'MVCTestContext' not found.")));

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
