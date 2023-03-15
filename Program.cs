
using ssc.Models;
using Microsoft.EntityFrameworkCore;
using ssc.Data;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
//Session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddDbContext<UserDepartmentDbContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<UserDepartmentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
//    services.AddControllersWithViews();
//}

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//--------------


if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
