using SoberDinner.API.Filters;
using SoberDinner.Application.Services;
using SoberDinner.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
