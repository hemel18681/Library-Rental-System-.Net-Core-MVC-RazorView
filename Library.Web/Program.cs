using Library.Web.Interfaces.Manager;
using Library.Web.Interfaces.Repository;
using Library.Web.Manager;
using Library.Web.Models;
using Library.Web.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDbConnectionString")));

builder.Services.AddTransient<IStudentsManager, StudentsManager>();
builder.Services.AddTransient<IBooksManager, BooksManager>();
builder.Services.AddTransient<IRentsManager, RentsManager>();


builder.Services.AddTransient<IRentsRepository, RentsRepository>();

var app = builder.Build();

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
    pattern: "{controller=Rental}/{action=Index}/{id?}");

app.Run();
