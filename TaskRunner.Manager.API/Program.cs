using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using TaskRunner.Manager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// See infrastructure layer for dependecy injection
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add swagger with API versioning
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskRunner Manager API", Version = "v1" });
});

builder.Services.AddApiVersioning();

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


