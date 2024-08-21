
using Microsoft.AspNetCore.Identity;
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

            builder.Services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.ClaimsIdentity.UserIdClaimType = "IdentityId";
            })
            .AddEntityFrameworkStores<DataContext>();
        }
    }
}
