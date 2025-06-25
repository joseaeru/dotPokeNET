using Application;
using Persistence;
using WebAPI.Extensions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence();
builder.Services.ConfigureApplication();
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfig();

WebApplication app = builder.Build();
app.AddSwaggerUI();
app.UseExceptionHandler("/Home/Error");
app.UseErrorHandler();
app.UseCors("DotPokeNETOrigins");//Use the CORS policy defined in CorsPolicyExtensions
app.UseStaticFiles();
app.MapControllers();
app.Run();