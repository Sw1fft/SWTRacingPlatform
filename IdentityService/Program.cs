using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityService.API.Extensions;
using IdentityService.Application.Abstractions;
using IdentityService.Application.DTO_s.Request;
using IdentityService.Application.Mappers;
using IdentityService.Domain.Models;
using IdentityService.Infrastructure.DataAccess;
using IdentityService.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddJwtAuthentication(configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new RegistrationService());
});

builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(IdentityServiceDbContext)));
});

builder.Services.AddAutoMapper(typeof(UserMapper));

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
