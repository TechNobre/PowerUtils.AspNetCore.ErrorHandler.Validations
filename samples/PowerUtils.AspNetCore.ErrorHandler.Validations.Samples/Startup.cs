using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Samples.Services;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Samples;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();


        services.AddValidationNotifications();
        services.AddErrorHandler();

        services.AddScoped<ITestService, TestService>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseEndpoints(endpoints
            => endpoints.MapControllers() // Mapping all controller
        );
    }
}
