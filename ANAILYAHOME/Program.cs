using ANAILYAHOME.entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ANAILYAHOME.Models;
using ANAILYAHOME.Repository.Base;
using ANAILYAHOME.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using ANAILYAHOME.Areas.Identity.Pages.Account;

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





//cookiese_____________________



builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
   .AddCookie();


//builder.Services.ConfigureApplicationCookie(options =>
//{
//   options.Cookie = new()
//    {
//        Name = "IdentityCookie",
//        HttpOnly = true,
//        SameSite = SameSiteMode.Lax,
//        SecurePolicy = CookieSecurePolicy.Always
//    };
//    options.SlidingExpiration = true;
//    options.ExpireTimeSpan = TimeSpan.FromDays(30);
//});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(20);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "ðþýöüçÖÇÞÝÜÐabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

//cookie

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie = new()
    {
        Name = "IdentityCookie",
        HttpOnly = true,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always
    };
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(20);
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});




//builder.services.AddAuthorization(options =>
//{
//    options.AddPolicy(DefaultAuthorizedPolicy, policy =>
//    {
//        policy.Requirements.Add(new TokenAuthRequirement());
//        policy.AuthenticationSchemes = new List<string>()
//        {
//            CookieAuthenticationDefaults.AuthenticationScheme
//        };
//    });
//});

//builder.Services.AddAuthorization( op =>
//op.AddPolicy("Roladmin", p => p.RequireClaim("ADMIN", "ADMIN"))
//);


builder.Services.AddScoped<IUserClaimsPrincipalFactory<AplicationUser>, MyUserClaimsPrincipalFactory>();
builder.Services.AddRazorPages();

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
