using MAPP.Application.DTOs;
using MAPP.Application.Extensions;
using MAPP.Application.Interfaces;
using MAPP.Infrastructure.Extensions;
using MAPP.Infrastructure.Persistence;
using MAPP.Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationMappings();
builder.Services.AddApplicationServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logService = scope.ServiceProvider.GetRequiredService<ILogService>();

    try
    {
        dbContext.SeedAdminUser();

        await logService.AddLog(new AddLogDto
        {
            Title = "Application Started",
            Description = $"App started successfully at {DateTime.Now}"
        });
    }
    catch (Exception ex)
    {
        await logService.AddLog(new AddLogDto
        {
            Title = "Startup Error",
            Description = ex.ToString()
        });

        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
