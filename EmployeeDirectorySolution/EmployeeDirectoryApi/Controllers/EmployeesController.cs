using EmployeeDirectoryApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public EmployeesController(EmployeesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/employees")]
    public async Task<ActionResult> GetAllEmployees()
    {
        var response = await _context.Employees.Select(emp => new EmployeeResponseModel
        {
            Id = emp.Id.ToString(),
            Email = emp.Email,
            FirstName = emp.FirstName,
            LastName = emp.LastName,
        }).OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToListAsync();
        return Ok(response);
    }

    [HttpPost("/employees")]
    public async Task<ActionResult> AddEmployee([FromBody] EmployeeRequestModel employee)
    {
        // This kind of mapping is required, tedious, and error-prone. Use AutoMapper
        var employeeToAdd = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Salary = employee.Salary,
        };

        _context.Employees.Add(employeeToAdd);
        await _context.SaveChangesAsync();

        return Ok(employeeToAdd);
    }
}


public record EmployeeRequestModel
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public decimal Salary { get; init; }
    public string Email { get; init; } = string.Empty;
}

public record EmployeeResponseModel
{
    public string Id { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}