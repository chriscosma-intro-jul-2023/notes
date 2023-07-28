using EmployeeDirectoryApi.Models;

namespace EmployeeDirectoryApi.Controllers;

public interface ILookupOnCallDevelopers
{
    Task<OnCallDeveloperResponseModel> FindCurrentDeveloperAsync();
}