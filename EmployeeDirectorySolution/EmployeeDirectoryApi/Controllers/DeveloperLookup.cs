using EmployeeDirectoryApi.Models;

namespace EmployeeDirectoryApi.Controllers;

public class DeveloperLookup : ILookupOnCallDevelopers
{
    private readonly IProvideTheBusinessesClock _businessClock;

    public DeveloperLookup(IProvideTheBusinessesClock businessClock)
    {
        _businessClock = businessClock;
    }

    public async Task<OnCallDeveloperResponseModel> FindCurrentDeveloperAsync()
    {
        OnCallDeveloperResponseModel response;
        if (_businessClock.AreWeOpen())
        {
            response = new OnCallDeveloperResponseModel()
            {
                Name = "Eli",
                PhoneNumber = "555-1212",
                Email = "eli@aol.com"
            };
        }
        else
        {
            response = new OnCallDeveloperResponseModel()
            {
                Name = "Becky",
                PhoneNumber = "555-9999",
                Email = "becky@aol.com"
            };
        }

        return response;
    }
}
