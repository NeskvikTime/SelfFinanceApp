using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SelfFinanceApp.Api.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IHostEnvironment _environment;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IHostEnvironment hostEnvironment)
        {
            _provider = provider;
            _environment = hostEnvironment;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = _environment.ApplicationName,
                        Version = description.ApiVersion.ToString(),
                    });
            }
        }
    }
}
