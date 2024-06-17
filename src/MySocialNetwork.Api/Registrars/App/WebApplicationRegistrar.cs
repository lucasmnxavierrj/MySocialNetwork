using Asp.Versioning.ApiExplorer;

namespace MySocialNetwork.Api.Registrars.App
{
    public class WebApplicationRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        $"MySocialNetwork v{description.ApiVersion}");
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }
    }
}
