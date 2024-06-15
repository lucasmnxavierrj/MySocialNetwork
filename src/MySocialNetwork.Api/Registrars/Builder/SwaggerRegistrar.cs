using Asp.Versioning.ApiExplorer;
using MySocialNetwork.Api.Options;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
