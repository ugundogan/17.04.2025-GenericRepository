using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDo_Cozuum.Data;
using ToDo_Cozuum.Mappers;
using ToDo_Cozuum.Repositories;
using ToDo_Cozuum.Services.EylemService;
using ToDo_Cozuum.Services.KategoriService;
using ToDo_Cozuum.Services.LoginService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<ToDooDbContext>(x => x.UseSqlServer(connectionString));

//Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ToDooDbContext>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(ToDoMapper));

builder.Services.AddTransient<EylemRepository>();
builder.Services.AddTransient<KategoriRepository>();

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IKategoriService, KategoriService>();
builder.Services.AddTransient<IEylemService, EylemService>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
