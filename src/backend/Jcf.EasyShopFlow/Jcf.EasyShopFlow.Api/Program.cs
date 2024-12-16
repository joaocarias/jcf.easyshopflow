using Jcf.EasyShopFlow.Api.Configs;
using Jcf.EasyShopFlow.Api.ProgramConfigs;

var consoleLogger = LoggerFactory.Create(b => b.AddConsole());

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomRepositories();
builder.Services.AddCustomServices(); 
builder.Services.AddAutoMapper(typeof(MappingConfig));

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

app.Run();
