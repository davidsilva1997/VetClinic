using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Data;
using VetClinicAPI.Repositories.Vet;
using VetClinicAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VetClinicDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default")));
});

builder.Services.AddScoped<IVetRepository, VetRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<VetValidator>();

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
