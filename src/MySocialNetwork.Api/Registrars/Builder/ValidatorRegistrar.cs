
using FluentValidation;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using MySocialNetwork.Api.Validators.UserProfile;

namespace MySocialNetwork.Api.Registrars.Builder
{
    public class ValidatorRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<UserProfileCreate>, UserProfileCreateValidator>();
            builder.Services.AddScoped<IValidator<UserProfileUpdate>, UserProfileUpdateValidator>();

        }
    }
}
