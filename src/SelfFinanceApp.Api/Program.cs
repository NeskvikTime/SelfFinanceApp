using Asp.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using SelfFinanceApp.Api.DbInitializer;
using SelfFinanceApp.Api.Filters;
using SelfFinanceApp.Api.Swagger;
using SelfFinanceApp.Application;
using SelfFinanceApp.Infrastructure;
using SelfFinanceApp.Persistance;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
}).AddMvc().AddApiExplorer();

builder.Services
    .AddControllers(cfg =>
    {
        cfg.Filters.Add(typeof(ExceptionFilter));
    })
    .AddNewtonsoftJson(options =>
    {
        options.UseMemberCasing();
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "SelfFinanceApp.Api", Version = "v1" });
    x.OperationFilter<SwaggerDefaultValues>();
    x.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date-only" });
}).AddSwaggerGenNewtonsoftSupport();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructureServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Host.UseSerilog((hbc, lc) =>
    lc.WriteTo.Console()
    .ReadFrom.Configuration(hbc.Configuration));

var app = builder.Build();

app.ApplyMigrations();

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in app.DescribeApiVersions())
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
    }
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SelfFinanceApp.Api");
});

app.MapHealthChecks("_health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
