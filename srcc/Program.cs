using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SmartCitySecurity.Data.Contexts;
using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.srcc.Repository.Implementations;
using SmartCitySecurity.srcc.Services;
using Microsoft.OpenApi.Models;
using SmartCitySecurity.Services;

var builder = WebApplication.CreateBuilder(args);

#region Inicializando o banco de dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
        opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
    );

#endregion

// Registro dos repositórios
builder.Services.AddScoped<ICrimeRepository, CrimeRepository>();
builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped<IRecursoPolicialRepository, RecursoPolicialRepository>();

// Corrigindo o registro do serviço
builder.Services.AddScoped<IRecursoService, RecursoService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Smart City Security API", Version = "v1" });
});

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
