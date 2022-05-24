using AutoMapper;
using CSVApplication.Business.Services;
using CSVApplication.Core.Interfaces;
using CSVApplication.Core.Models;
using CSVApplication.DataAccess;
using CSVApplication.DataAccess.Repository;
using CSVApplication.Entities;
using CSVApplication.WebAPI.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Autorization",
        Description = "Bearer Authentication with JWT Token"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { 
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{ 
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddAuthorization();
//JWT configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Get AppSettings conection string name
var enviromentValue = builder.Configuration["ConnectionString"];

// SQL Server configuration
builder.Services.AddDbContext<AppContextDB>
        (con => con.UseSqlServer(Environment.GetEnvironmentVariable(enviromentValue) ?? string.Empty));

// Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Dependency Injection
builder.Services.AddTransient<CSVBodyService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddScoped<IRepository<CSVBodyEntity>, Repository<CSVBodyEntity>>();
builder.Services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();

// CORS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Login Method
IResult Login(UserLoginDTO login, UserService service, IMapper mapper)
{
    var user = service.Login(mapper.Map<UserLoginModel>(login));
    if (user is null) return Results.NotFound();
    var claims = new[] {
        new Claim(ClaimTypes.NameIdentifier, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Surname, user.Surname),
        new Claim(ClaimTypes.Role, user.Role),
    };
    var token = new JwtSecurityToken(
        issuer: builder.Configuration["Jwt:Issuer"],
        audience: builder.Configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddDays(60),
        notBefore: DateTime.UtcNow,
        signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256
            )
        );
    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    var userResult = mapper.Map<UserDTO>(user);
    userResult.Token = tokenString;
    return Results.Ok(userResult);
}


// API list
app.MapGet("/", (CSVBodyService service) => "Welcome to my minimal API Service built with .NET 6.0, for more information please consult documentation in /swagger");

app.MapGet("/getAll",
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Standard, Administrator")]
(CSVBodyService service) => service.GetAll());

app.MapPost("/create",
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
(CSVBodyDTO model, CSVBodyService service, IMapper mapper) => service.Create(mapper.Map<CSVBodyModel>(model)));

app.MapPut("/update",
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
(CSVBodyDTO model, CSVBodyService service, IMapper mapper) => service.Update(mapper.Map<CSVBodyModel>(model)));

app.MapDelete("/delete/{id}",
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
(int id, CSVBodyService service) => service.Delete(id));

app.MapPost("/processString", 
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")] 
(CSVBodyDTO model, CSVBodyService service, IMapper mapper) => service.ProcessString(mapper.Map<CSVBodyModel>(model)));

app.MapPost("/login", 
    (UserLoginDTO login, UserService service, IMapper mapper) => Login(login, service, mapper));


app.UseRouting();
//Enable Authentication
app.UseAuthentication();
app.UseAuthorization();  
app.Run();
