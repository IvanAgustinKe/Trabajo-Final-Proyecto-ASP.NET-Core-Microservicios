using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Infrastructure.Data;
using CustomerMicroservice.Application.Interfaces;
using CustomerMicroservice.Infrastructure.Repositories;
using FluentValidation;
using CustomerMicroservice.Application.Validators;
using MediatR;
using AutoMapper;
using CustomerMicroservice.Application.Mapping;
using FluentValidation.AspNetCore;
using CustomerMicroservice.Application.Customers.Commands;
using CustomerMicroservice.Application.Customers.Queries;

var builder = WebApplication.CreateBuilder(args);

// 1. EF Core
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2. Repository Pattern
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// 3. FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// 4. MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<GetAllCustomersQueryHandler>()
);

// 5. AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

// 6. CORS 
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

// 7. Controladores
builder.Services.AddControllers();

// 8. Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 9. VALIDACIÓN AutoMapper
var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

// 10. Swagger UI en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 11. CORS 
app.UseCors("AllowFrontend");

// 12. Middlewares
app.UseHttpsRedirection();

// 13. controladores
app.MapControllers();

app.Run();
