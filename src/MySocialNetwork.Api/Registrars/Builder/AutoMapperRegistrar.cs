
using MySocialNetwork.Application;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class AutoMapperRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(AssemblyReference));
        }
    }
}
