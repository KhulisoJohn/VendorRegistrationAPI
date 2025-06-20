using VendorRegistrationAPI.Data;
using VendorRegistrationAPI.Models;
using VendorRegistrationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load env variables from .env file
DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

// Read env vars
var serveName = Environment.GetEnvironmentVariable("DB_SERVER");
var passWord = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Construct connection string manually
var connectionString = $"Server={serveName};Port=5432;Database=VendorDb;User Id=postgres;Password={passWord};";

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VendorDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register vendor business logic service
builder.Services.AddScoped<VendorService>();

// Configure JSON to support enum strings (case-insensitive)
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// POST endpoint for vendor registration
app.MapPost("/api/vendors/register", async (
    VendorRegistrationDto dto,
    VendorService vendorService) =>
{
    var (isValid, errors, vendor) = await vendorService.RegisterVendorAsync(dto);

    if (!isValid)
        return Results.BadRequest(errors);

    return Results.Ok(new { id = vendor.Id, message = "Vendor registered successfully" });
});

app.Run();
