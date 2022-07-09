using WebApplication3.Repositorio;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

//Informação que estava no appsettings.json
// Para trocar o banco de dados só ir no appsettings.json e mudar as informações da Database.

// Para o banco de dados funcionar voce deve fazer a seguinte forma
// Colocar rodar no console nuget packages o seguinte comando: Add-Migration CriandoTabelaContatos -Context BancoContext
// Depois disso você roda esse outro comando aqui: Update-Database -Context BancoContext



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
