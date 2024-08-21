using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MySocialNetwork.Api.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            var scheme = GetJwtSecurityScheme();
            options.AddSecurityDefinition(scheme.Reference.Id, scheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {scheme, new string[0]}
            });
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "MySocialNetwork",
                Version = description.ApiVersion.ToString(),
            };

            if (description.IsDeprecated)
                info.Description = "THIS API VERSION IS DEPRECATED! USE THE MOST RECENT!";

            return info;
        }

        private OpenApiSecurityScheme GetJwtSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Provide a JWT Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
        }
    }
}
