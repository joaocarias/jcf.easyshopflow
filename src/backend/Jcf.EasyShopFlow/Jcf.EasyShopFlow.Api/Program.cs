using Jcf.EasyShopFlow.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

var consoleLogger = LoggerFactory.Create(b => b.AddConsole());

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        options.EnableSensitiveDataLogging();
        if (builder.Environment.IsDevelopment())
        {
            options.UseLoggerFactory(consoleLogger).EnableDetailedErrors();
        }
    }
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
