
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySocialNetwork.Application.Options;
using System.Text;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class IdentityRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var jwtSettings = new JwtSettings();
            builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);

            // DI
            var jwtSection = builder.Configuration.GetSection(nameof(jwtSettings));
            builder.Services.Configure<JwtSettings>(jwtSection);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SigningKey)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudiences = jwtSettings.Audiences,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,

                };
                options.Audience = jwtSettings.Audiences[0];
                options.ClaimsIssuer = jwtSettings.Issuer;
            });
        }
    }
}
