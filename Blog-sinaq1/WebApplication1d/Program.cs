using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1d.Contexts;
using WebApplication1d.Helpers;
using WebApplication1d.Models;

namespace WebApplication1d
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BlogDbContext>(opt =>
            {
                //opt.UseSqlServer(builder.Configuration["ConnectionStrings:MSSQL"]);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            }).AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<BlogDbContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
            //    options.LoginPath = new PathString("/Auth/Login");
            //    options.LogoutPath = new PathString("/Auth/Logout");
            //    options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            //    options.AccessDeniedPath = new PathString("/Home/AccessDenied");

                options.Cookie = new()
                {
                    Name = "IdentityCookie",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });
            builder.Services.AddScoped<SliderIMGService>();
            builder.Services.AddSession();

            var app = builder.Build();
            //builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<BlogDbContext>();
            //builder.Services.AddRazorPages();

            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    options.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;
            //});

            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            PathConst.roothpath= app.Environment.WebRootPath;
            app.Run();
        }
    }
}