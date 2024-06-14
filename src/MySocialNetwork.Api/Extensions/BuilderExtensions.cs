using Asp.Versioning.ApiExplorer;

namespace MySocialNetwork.Api.Extensions
{
    public static class BuilderExtensions
    {
        public static WebApplication AddDebugConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            $"MySocialNetwork v{description.ApiVersion}");
                    }
                });
            }

            return app;
        }
    }
}
