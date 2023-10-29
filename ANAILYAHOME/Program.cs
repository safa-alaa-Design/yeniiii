using ANAILYAHOME.entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ANAILYAHOME.Models;
using ANAILYAHOME.Repository.Base;
using ANAILYAHOME.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AplicetionDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("urunlercnn")));

builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));




builder.Services.AddIdentity<AplicationUser,IdentityRole<int>>()
    .AddRoles<IdentityRole<int>>()
   .AddEntityFrameworkStores<AplicetionDbContext>()
   .AddUserManager<UserManager<AplicationUser>>()
   .AddRoleManager<RoleManager<IdentityRole<int>>>()
   .AddDefaultUI()
   .AddDefaultTokenProviders();

//builder.Services.AddAuthorization(op =>
//op.AddPolicy("Roladmin", p => p.RequireClaim("ADMIN", "ADMIN"))
//);
//builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.UseAuthentication();;
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
