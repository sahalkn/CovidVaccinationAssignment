using CovidVaccinationPatientDetailsSystem.Data;
using CovidVaccinationPatientDetailsSystem.Models;
using CovidVaccinationPatientDetailsSystem.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static CovidVaccinationPatientDetailsSystem.Repositories.IRepository;

var builder = WebApplication.CreateBuilder(args);

// FluentValidation setup
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Add API Explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "COVID Vaccination API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CovidContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IRepository<Vaccination>, VaccinationRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "COVID Vaccination API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
