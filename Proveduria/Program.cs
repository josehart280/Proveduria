using Microsoft.EntityFrameworkCore;
using Proveduria;
using Proveduria.Servicios.Contrato;
using Proveduria.Servicios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Añade la configuración
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProveeduriaPiiContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConnectionStrings:ProveduriaWebContext");
    options.UseSqlServer(connectionString);
});



builder.Services.AddScoped<IUsuarioService, UsuarioService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Inicio/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
