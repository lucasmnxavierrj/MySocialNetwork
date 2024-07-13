using MySocialNetwork.Application;
using System.Reflection;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class MediatrRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(AssemblyReference)));
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
