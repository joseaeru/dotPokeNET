namespace WebAPI.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Retrieve the list of allowed origins from the configuration
            List<string> dotPokeNETOrigins = configuration.GetSection("DotPokeNETOrigins").Get<List<string>>() ?? [];
             
            if (dotPokeNETOrigins.Count > 0)
            {
                services.AddCors(opt =>
                {
                    opt.AddPolicy("DotPokeNETOrigins", builder => builder
                        .WithOrigins(dotPokeNETOrigins.ToArray())// Specify the allowed origins from the configuration
                        //.AllowAnyOrigin()// Uncomment this line if you want to allow any origin
                        .AllowAnyMethod()// Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader()// Allow any HTTP header
                        .AllowCredentials()
                        );// Allow credentials (cookies, authorization headers, etc.)
                });
            }
        }
    }
}
