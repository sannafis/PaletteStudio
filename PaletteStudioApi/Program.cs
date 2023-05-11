
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Serilog;
using PaletteStudioApi.Data;
using Microsoft.EntityFrameworkCore;
using JsonSubTypes;
using PaletteStudioApi.Models;
using PaletteStudioApi.Utilities;
using Microsoft.AspNetCore.Identity;
using PaletteStudioApi.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;
using PaletteStudioApi.Services;
using PaletteStudioApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.Security.Policy;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("PaletteStudioDbContext");
builder.Services.AddDbContext<PaletteStudioDbContext>(options =>
{
    options.UseSqlite(connString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Palette Studio API",
        Version = "v1",
    });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization Header using the Bearer scheme. 
                        Scheme: 'Bearer {token}' 
                        Example: 'Bearer 123abc'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "0auth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>("PaletteStudioApi")
    .AddEntityFrameworkStores<PaletteStudioDbContext>()
    .AddDefaultTokenProviders();

var key = builder.Configuration["JwtSettings:Key"]; // Demo Purposes

if (builder.Environment.IsDevelopment())
{
    key = builder.Configuration["JwtSettings:SecretKey"]; // Actual Key
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPalettesRepository, PalettesRepository>();
builder.Services.AddScoped<IColoursRepository, ColoursRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

//builder.Services.AddResponseCaching(options =>
//{
//    options.MaximumBodySize = 1024;
//    options.UseCaseSensitivePaths = true;
//});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandler>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

//app.UseResponseCaching();

//app.Use(async (context, next) =>
//{
//    context.Response.GetTypedHeaders().CacheControl =
//        new CacheControlHeaderValue()
//        {
//            Public = true,
//            MaxAge = TimeSpan.FromSeconds(5)
//        };
//    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };
//    await next();
//});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();