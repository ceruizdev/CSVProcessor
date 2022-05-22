using AutoMapper;
using CSVApplication.Business.Services;
using CSVApplication.Core.Interfaces;
using CSVApplication.Core.Models;
using CSVApplication.DataAccess;
using CSVApplication.DataAccess.Repository;
using CSVApplication.Entities;
using CSVApplication.WebAPI.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Get AppSettings conection string name
var enviromentValue = builder.Configuration["ConnectionString"];

// SQL Server configuration
builder.Services.AddDbContext<AppContextDB>
        (con => con.UseSqlServer(Environment.GetEnvironmentVariable(enviromentValue) ?? string.Empty));

// Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Dependency Injection
builder.Services.AddTransient<CSVBodyService>();
builder.Services.AddScoped<IRepository<CSVBodyEntity>, Repository<CSVBodyEntity>>();

// CORS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("corsapp");
//app.UseAuthorization();
// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// API list
app.MapGet("/", (CSVBodyService service) => "Welcome to my minimal API Service built with .NET 6.0, for more information please consult documentation in /swagger");
app.MapGet("/getAll", (CSVBodyService service) => service.GetAll());
app.MapPost("/create", (CSVBodyDTO model, CSVBodyService service, IMapper mapper) => service.Create(mapper.Map<CSVBodyModel>(model)));
app.MapPut("/update", (CSVBodyDTO model, CSVBodyService service, IMapper mapper) => service.Update(mapper.Map<CSVBodyModel>(model)));
app.MapDelete("/delete/{id}", (int id, CSVBodyService service) => service.Delete(id));

app.Run();
