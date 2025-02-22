using Microsoft.EntityFrameworkCore;
using MovieCollectionApp.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Register the MovieDbContext with EF Core + SQLite
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Add services for MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3) Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapControllerRoute(
    name: "movies",
    pattern: "{controller=Movies}/{action=MovieList}/{id?}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);



app.Run();