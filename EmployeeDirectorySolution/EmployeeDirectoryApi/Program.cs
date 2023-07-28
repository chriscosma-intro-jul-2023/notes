using EmployeeDirectoryApi;
using EmployeeDirectoryApi.Controllers;
using EmployeeDirectoryApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var employeeConnectionString = builder.Configuration.GetConnectionString("employees") ?? throw new Exception("can't find connection string");
builder.Services.AddDbContext<EmployeesDataContext>(options =>
{
    options.UseNpgsql(employeeConnectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProvideTheBusinessesClock, StandardBusinessClock>();
builder.Services.AddScoped<ILookupOnCallDevelopers, DeveloperLookup>();
builder.Services.AddSingleton<ISystemTime, SystemTime>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// This will add to the internal class Main so we can see it from tests
public partial class Program { }