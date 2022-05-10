using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var connectString = builder.Configuration.GetConnectionString("MVCTestContext");
var databaseName = "MVCTestContext-9682b5ae-3fa3-4b3c-a2f9-80cdcb5b6484";

// Check if database exists in the computer. If it does not, create the database
SqlConnection dbConnection = new SqlConnection(connectString);
var command = new SqlCommand($"SELECT db_id('" + databaseName + "')", dbConnection);

dbConnection.Open();

if (command.ExecuteScalar() == DBNull.Value)
{
    command = new SqlCommand($"CREATE DATABASE [" + databaseName + "] ON PRIMARY( NAME = " + databaseName + "_data, FILENAME = 'C:\\" + databaseName + "_data.mdf') LOG ON( NAME = " + databaseName + "_log, FILENAME = 'C:\\" + databaseName + "_log.ldf'", dbConnection);
    command.ExecuteNonQuery();
}

if (dbConnection.State == ConnectionState.Open)
{
    dbConnection.Close();
}

builder.Services.AddDbContext<MVCTestContext>(options =>
    options.UseSqlServer(connectString ?? throw new InvalidOperationException("Connection string 'MVCTestContext' not found.")));

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
