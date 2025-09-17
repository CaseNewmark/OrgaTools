using System.Security.Claims;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using OrgaTools.Api.Database;
using OrgaTools.Api.Mappers;
using OrgaTools.Services.Whiteboard;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string
var connStr = builder.Configuration.GetConnectionString("orgatools-database")
              ?? Environment.GetEnvironmentVariable("POSTGRES_CONNECTION");

// Register your DbContexts
builder.Services.AddDbContext<OrgaToolsDbContext>(opt =>
    opt.UseNpgsql(connStr));

// Load user-secrets only for local dev -- This is done to load License key local dev Private key and pass phrase
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}
else
{
    // QA/Prod → use Azure Key Vault
}

// Add controller services
builder.Services.AddControllers();

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// the actual services that will be used in the application
builder.AddWhiteboardServices();

//Authentication Setup
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

//Add Mapperly DI
builder.Services.AddSingleton<SampleMapperProfile, SampleMapperProfile>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    using (var scope = app.Services.CreateScope())
    {
        Console.WriteLine("Applying migrations to database:");
        var dbContext = scope.ServiceProvider.GetRequiredService<OrgaToolsDbContext>();
        dbContext.Database.Migrate();
    }
}

// Development-only fake user for testing
if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "devuser"),
            new Claim(ClaimTypes.Email,"default@default.com"),
            new Claim(ClaimTypes.Surname,"test"),
            new Claim(ClaimTypes.GivenName,"test user"),
            new Claim(ClaimTypes.Role, "Sample.Role"), // Add role for [Authorize]
        };
        context.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "DevAuth"));
        await next();
    });
}

app.UseRouting();

// Map controller endpoints
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
