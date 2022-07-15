using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddDebug();
// Add services to the container.

var app = builder.Build();

app.Logger.LogInformation("The app started");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Ok("Hello"));

app.MapPost("/login", new LoginMicroService.Ports.IAPI.RESTHandler<string>(LoginMicroService.Mappings.login.Login.doLogin));

app.Run();

