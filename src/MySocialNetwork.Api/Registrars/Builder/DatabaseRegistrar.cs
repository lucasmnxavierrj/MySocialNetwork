
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Infraestructure.DataAccess;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class DatabaseRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connectionString));
        }
    }
}
