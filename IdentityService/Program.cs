using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityService.Application.DTO_s.Request;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new RegistrationService());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapPost("/api/login", async (LoginRequestDto request, IUserService service) =>
{
    var result = await service.LoginAsync(request);

    return Results.Ok(result);
});

app.MapPost("/api/register", async (RegisterRequestDto request, IUserService service) =>
{
    var result = await service.RegisterAsync(request);

    return Results.Ok(result);
});

app.Run();
