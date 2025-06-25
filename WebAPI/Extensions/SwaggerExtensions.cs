using Microsoft.OpenApi.Models;


namespace WebAPI.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                //ADD JWT AUTHORIZATION
                s.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT de autorizacion asociado a su usuario.",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    }
                );

                //ADD JWT AUTHORIZATION
                s.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference{
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    }
                );

                //ADD XML DOCS
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "dotPokeNET",
                    Description = "return a PokeAPI EndPoint to retrieve info about Pokémon.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Support",
                        Email = "support@domain.co",
                        Url = new Uri("https://github.com/CorneliusDVon/dotPokeNET"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Corneliud D. Von ® 2025",
                        Url = new Uri("https://github.com/CorneliusDVon/dotPokeNET"),
                    },
                    TermsOfService = new Uri("https://github.com/CorneliusDVon/dotPokeNET")
                });
                s.CustomSchemaIds(s => s.FullName.Replace("+", "."));//REPLACE + WITH . IN SCHEMA IDS TO AVOID DUPLICATES
            });

        }

        public static void AddSwaggerUI(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.DefaultModelsExpandDepth(-1);//HIDE MODELS IN SWAGGER UI
                    options.SwaggerEndpoint("../swagger/v1/swagger.json", "dotPokeNET v1");//SWAGGER ENDPOINT
                    options.InjectStylesheet("/src/swagger-ui/SwaggerDark.css");//CUSTOM STYLESHEET FOR SWAGGER UI              
                }
            );
        }
    }
}
