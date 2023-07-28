
using Alba;
using EmployeeDirectoryApi.Controllers;
using EmployeeDirectoryApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EmployeeDirectoryApi.ContractTests.OnCallDeveloper;

public class GettingTheOnCallDeveloper
{
    [Fact]
    public async Task MakingTheRequestDuringBusinessHours()
    {
        // --- Given ---
        // Variable that has the API up and running
        // using keyword says to get rid of the host at the end of this test so we don't reuse it
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var stubbedClock = new Mock<IProvideTheBusinessesClock>();
                stubbedClock.Setup(x => x.AreWeOpen()).Returns(true);
                services.AddSingleton<IProvideTheBusinessesClock>(stubbedClock.Object);
            });
        });
        var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
        {
            Name = "Eli",
            Email = "eli@aol.com",
            PhoneNumber = "555-1212",
        };

        // --- Then ---
        var responseMessage = await host.Scenario(api =>
        {
            api.Get.Url("/on-call-developer");
            api.StatusCodeShouldBeOk();
        });

        var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
        Assert.NotNull(response);
        Assert.Equal(expectedOnCallDeveloper, response);

    }

    [Fact]
    public async Task MakingTheRequestOutsideBusinessHours()
    {
        // --- Given ---
        // Variable that has the API up and running
        // using keyword says to get rid of the host at the end of this test so we don't reuse it
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var stubbedClock = new Mock<IProvideTheBusinessesClock>();
                stubbedClock.Setup(x => x.AreWeOpen()).Returns(false);
                services.AddSingleton<IProvideTheBusinessesClock>(stubbedClock.Object);
            });
        }); var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
        {
            Name = "Becky",
            Email = "becky@aol.com",
            PhoneNumber = "555-9999",
        };

        // --- Then ---
        var responseMessage = await host.Scenario(api =>
        {
            api.Get.Url("/on-call-developer");
            api.StatusCodeShouldBeOk();
        });

        var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
        Assert.NotNull(response);
        Assert.Equal(expectedOnCallDeveloper, response);

    }
}
