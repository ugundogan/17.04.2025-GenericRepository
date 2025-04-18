using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.MapperClasses;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodoDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddIdentity<Uye, Rol>(x => x.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<TodoDbContext>().AddRoles<Rol>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index"; //  Giriş yapılmamışsa buraya yönlendirir
    options.AccessDeniedPath = "/Login/YetkisizGiris"; // Giriş yapmış ama yetki yoksa
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<YapilacakService>();

builder.Services.AddTransient<YapilacakRepository>();
builder.Services.AddTransient<KategoriRepository>();

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
