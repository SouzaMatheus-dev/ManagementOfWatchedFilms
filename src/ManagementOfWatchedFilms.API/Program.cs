using ManagementOfWatchedFilms.API.Infrastructure.AutoMapper;
using ManagementOfWatchedFilms.Domain.Interface.Service;
using ManagementOfWatchedFilms.Infrastructure.Core.Extensions;
using ManagementOfWatchedFilms.Infrastructure.CrossCutting.InversionOfControl;
using ManagementOfWatchedFilms.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapperDependency();
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddInfrastructureDependency(configuration);

builder.Services.AddDbContext<EntityContext>(options =>
{
    options.UseSqlServer();
});

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