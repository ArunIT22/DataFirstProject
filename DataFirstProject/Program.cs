using DataFirstProject.Areas.BikeStore.Repositories;
using DataFirstProject.Models;
using DataFirstProject.Models.BikeStores;
using DataFirstProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Resolve ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<BikeStoresContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("BikeStoresConnection")));
builder.Services.AddDbContext<DataFirstProject.Areas.BikeStore.Models.BikeStoresContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("BikeStoresConnection")));

//Resolve IOrderRepository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

app.MapAreaControllerRoute(
     name: "MyBikeStoreArea",
     areaName: "BikeStore",
     pattern: "BikeStore/{controller=Home}/{action=index}/{id?}"
    );

app.MapControllerRoute(
       name: "areaRoute",
       pattern: "{area:exists}/{controller}/{action}"
   );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
