using Microsoft.Extensions.DependencyInjection;
using PowerUtils.Validations;

namespace PowerUtils.AspNetCore.ErrorHandler
{
    public static class ValidationNotificationsMiddleware
    {
        public static IServiceCollection AddValidationNotifications(this IServiceCollection services)
        {
            services.AddScoped<IValidationNotifications, ValidationNotifications>();
            services.AddMvc(options => options.Filters.Add<ValidationNotificationsFilter>());

            return services;
        }
    }
}
