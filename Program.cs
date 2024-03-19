using Microsoft.EntityFrameworkCore;
using TechnoManagment.Context;
using TechnoManagment.Models;
using TechnoManagment.Repository;
using TechnoManagment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConn"), builder => builder.EnableRetryOnFailure(6, TimeSpan.FromSeconds(10), null));
});

builder.Services.AddScoped(typeof(IGenaricRepository<EmployeeVacation>),typeof(EmployeeVacationRepo));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
