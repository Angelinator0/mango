using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервис для подключения к базе данных через DbContext
// Строка подключения берётся из appsettings.json (ключ "DefaultConnection")
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем поддержку контроллеров с представлениями (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// создаём/обновляем БД 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
     
    db.Database.EnsureCreated();          
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// маршрутизация по умолчанию на список студентов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();