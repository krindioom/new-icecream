using Microsoft.AspNetCore.Authentication.JwtBearer;
using NewIceCream.DAL;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NewIceCream.DAL.Repository;
using NewIceCream.Service.Services.Authorizations;
using IAuthorizationService = NewIceCream.Service.Services.Authorizations.IAuthorizationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using NewIceCream.Service.Services.IceCreamBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Authorization/Register";
});


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<IcecreamDbContext>(option => option.UseSqlServer(connection));

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryProxy<>));
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IIceCreamCreationService, IceCreamCreationService>();
builder.Services.AddScoped<IIceCreamBuilderService, IceCreamBuilderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
