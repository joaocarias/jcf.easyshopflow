using Jcf.EasyShopFlow.Api.Configs;
using Jcf.EasyShopFlow.Infra.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddScoped<AppDapperContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Jwt:Key"])),
            ValidAudience = builder.Configuration["Authentication:Jwt:Audience"],
            ValidIssuer = builder.Configuration["Authentication:Jwt:Issuer"],
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
        };
    }
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomRepositories();
builder.Services.AddCustomServices(); 

builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
