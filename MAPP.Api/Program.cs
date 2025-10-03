using Microsoft.EntityFrameworkCore;
using MAPP.Infrastructure.Persistence;
using MAPP.Infrastructure.Persistence.Seed;
using MAPP.Application.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var encryptionKey = builder.Configuration["EncryptionKey"] ?? "12345678901234567890123456789012";
    var encryptionService = new AesEncryptionService(encryptionKey);

    var dbSettings = builder.Configuration.GetSection("DatabaseSettings");
    var serverName = dbSettings["ServerName"];
    var databaseName = dbSettings["DatabaseName"];
    var userName = dbSettings["UserName"];
    var encryptedPassword = dbSettings["Password"];
    var encrypt = dbSettings.GetValue<bool>("Encrypt");
    var trustServerCertificate = dbSettings.GetValue<bool>("TrustServerCertificate");

    var password = encryptionService.Decrypt(encryptedPassword!);

    var connectionString =
        $"Server={serverName};Database={databaseName};User Id={userName};" +
        $"Password={password};Encrypt={encrypt};TrustServerCertificate={trustServerCertificate};";

    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.SeedAdminUser();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
