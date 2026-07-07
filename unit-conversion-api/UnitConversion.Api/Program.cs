using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using UnitConversion.Api.Middlewares;
using UnitConversion.Application;
using UnitConversion.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Layer
builder.Services.AddApplication();

// Infrastructure Layer
builder.Services.AddInfrastructure();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();