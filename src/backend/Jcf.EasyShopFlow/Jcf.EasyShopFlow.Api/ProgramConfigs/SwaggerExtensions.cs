using Microsoft.OpenApi.Models;

namespace Jcf.EasyShopFlow.Api.Configs
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Jcf.EasyShopFlow.Api",
                    Version = "v1",
                    Description = "Desenvolvido em C# - Net 8",
                    Contact = new OpenApiContact
                    {
                        Name = "Joao Carias de Franca",
                        Email = "joaocariasdefranca@gmail.com",
                        Url = new Uri("https://github.com/joaocarias")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Copie 'Bearer ' + token' ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }
    }
}
