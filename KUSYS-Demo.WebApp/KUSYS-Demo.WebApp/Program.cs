using KUSYS_Demo.DataAccess.Contexts.Abstract;
using KUSYS_Demo.DataAccess.Contexts.Concrete;
using KUSYS_Demo.Services.Abstract;
using KUSYS_Demo.Services.Concrete;
using KUSYS_Demo.WebApp.AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KusysDbContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("KusysConnectionString")));
builder.Services.AddAutoMapper(typeof(KusysProfile));
builder.Services.AddScoped<IKusysDbContext, KusysDbContext>();
builder.Services.AddScoped<IStudentService, StudentService>();
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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
