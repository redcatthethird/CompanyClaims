using System.Text.Json.Serialization;

using CompanyClaims.Api.Services;
using CompanyClaims.Data;
using CompanyClaims.Data.Repos;
using CompanyClaims.Data.Repos.Interfaces;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DefaultDbContext>();

builder.Services.AddTransient<ICompanyRepo, CompanyRepo>();
builder.Services.AddTransient<IClaimRepo, ClaimRepo>();

builder.Services.AddTransient<CompanyService>();
builder.Services.AddTransient<ClaimService>();

builder.Services.AddControllers()
    .AddJsonOptions(jsonOptions =>
    {
        jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompanyClaims API", Description = "Interact with test insurance data", Version = "v1" });
});

builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyClaims API v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors();

app.MapControllers();

using (var context = new DefaultDbContext())
{
    await context.AddSeedData();
}

app.Run();
