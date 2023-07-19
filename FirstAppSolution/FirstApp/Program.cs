using FirstApp.Models;

Console.WriteLine("Starting up the Api");
var builder = WebApplication.CreateBuilder(args);
// Configuration for the Api goes here

Console.WriteLine("About to start the Api");
var app = builder.Build();

// Route GET "/sayhi"
app.MapGet("/sayhi", () =>
{
    return Results.Ok("Yep! Hello, Good To See You!");
});

app.MapGet("/status", () =>
{
    var response = new StatusResponseModel(DateTime.Now, "Looks Good", "Operating Normally");
    return Results.Ok(response);
});


app.Run(); // Blocking call - starts server and runs until we kill it
Console.WriteLine("Api is shutting down");