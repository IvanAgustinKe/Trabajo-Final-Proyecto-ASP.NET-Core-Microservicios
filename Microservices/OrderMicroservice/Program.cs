using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Infrastructure.Data;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Infrastructure.Repositories;
using OrderMicroservice.Infrastructure.Services;
using FluentValidation;
using OrderMicroservice.Application.Validators;
using MediatR;
using AutoMapper;
using OrderMicroservice.Application.Mapping;
using FluentValidation.AspNetCore;
using OrderMicroservice.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. EF Core: DbContext + SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2. Repository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// 3. HTTP clients para Customer y Product
var customerUrl = builder.Configuration["Services:Customer"];
if (string.IsNullOrWhiteSpace(customerUrl))
    throw new InvalidOperationException("Falta la URL de Customer en Services:Customer.");

var productUrl = builder.Configuration["Services:Product"];
if (string.IsNullOrWhiteSpace(productUrl))
    throw new InvalidOperationException("Falta la URL de Product en Services:Product.");

builder.Services
    .AddHttpClient<ICustomerServiceClient, CustomerServiceClient>(c =>
        c.BaseAddress = new Uri(customerUrl));

builder.Services
    .AddHttpClient<IProductServiceClient, ProductServiceClient>(c =>
        c.BaseAddress = new Uri(productUrl));

// 3.1  política CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")  // Ajusta si tu SPA corre en otro puerto
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// 4. FluentValidation 
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

// 5. MediatR 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()
);

// 6. AutoMapper (registra tu OrderProfile)
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);

// 7. Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 8. Swagger UI solo en Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8.1 política CORS 
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

// middleware de excepciones
app.UseGlobalExceptionHandler();

app.MapControllers();

app.Run();
