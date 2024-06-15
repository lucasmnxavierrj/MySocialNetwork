using MySocialNetwork.Api.Registrars;

namespace MySocialNetwork.Api.Registrars.App
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        void RegisterPipelineComponents(WebApplication app);
    }
}
