using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Data;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;
using PruebaNET_BrayanFelipeRodriguezMosquera.Services;
using RepasoJWT.Config;

Env.Load();

var host = Environment.GetEnvironmentVariable("DB_HOST");
var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var username = Environment.GetEnvironmentVariable("DB_USERNAME");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"server={host};port={port};database={databaseName};uid={username};password={password}";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.20-mysql")));
builder.Services.AddControllers();
builder.Services.AddScoped<IRoomTypeRepository,RoomTypeServices>();
builder.Services.AddScoped<IRoomRepository,RoomServices>();
builder.Services.AddScoped<IGuestRepository,GuestServices>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeServices>();
builder.Services.AddScoped<IBookingRepository,BookingServices>();

// ACA HABILITAMOS LA OPCION QUE NOS PERMITE USAR JWT
builder.Services.AddSingleton<JWT>();
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});

app.MapControllers();

app.Run();
