using DataFirstProject.Areas.BikeStore.Models;
using DataFirstProject.Models;
using DataFirstProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Resolve ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<BikeStoresContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BikeStoresConnection")));

//Resolve IOrderRepository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<DataFirstProject.Areas.BikeStore.Repositories.IProductRepository, DataFirstProject.Areas.BikeStore.Repositories.ProductRepository>();

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

////Conventional Routing
//app.MapAreaControllerRoute(
//    name: "MyBikeStore",
//    areaName: "BikeStore",
//    pattern: "BikeStore/{controller=Home}/{action=Index}/{id?}"
//    );

//app.MapControllerRoute(
//    name: "areaRoute",
//    pattern: "{area:exists}/{controller}/{action}/{id?}"
//    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
