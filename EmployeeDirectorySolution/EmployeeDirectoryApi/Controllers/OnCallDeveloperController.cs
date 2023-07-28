using EmployeeDirectoryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryApi.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    private readonly ILookupOnCallDevelopers _oncallDeveloperLookup;

    public OnCallDeveloperController(ILookupOnCallDevelopers oncallDeveloperLookup)
    {
        _oncallDeveloperLookup = oncallDeveloperLookup;
    }

    [HttpGet("/on-call-developer")]
    public async Task<ActionResult> Get()
    {
        OnCallDeveloperResponseModel response = await _oncallDeveloperLookup.FindCurrentDeveloperAsync();
        return Ok(response);
    }
}
