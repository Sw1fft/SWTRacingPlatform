using AccountService.Domain.Abstractions.Services;
using AccountService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHeaderService, HeaderService>();

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
app.UseAuthorization();
app.MapControllers();

app.Run();
