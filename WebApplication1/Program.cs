using WebApplication1.Data;
using WebApplication1.MapperClasses;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SahafDbContext>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<KitapRepository>();
builder.Services.AddTransient<KategoriRepository>();
builder.Services.AddTransient<YayinEviRepository>();
builder.Services.AddTransient<YazarRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
