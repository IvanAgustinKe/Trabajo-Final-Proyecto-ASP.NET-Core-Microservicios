using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Infrastructure.Repositories;
using ProductMicroservice.Application.Validators;
using MediatR;
using ProductMicroservice.Application.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// 1. EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2. Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// 3. **CORS**: 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
          .WithOrigins("http://localhost:5173")   
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});

// 4. Controllers
builder.Services.AddControllers();

// 5. AutoMapper
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

// 6. FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

// 7. MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// 8. Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 9. **CORS**: 
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 10. maps controllers
app.MapControllers();

app.Run();
