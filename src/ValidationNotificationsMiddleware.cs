using System;
using Microsoft.Extensions.DependencyInjection;
using PowerUtils.Validations;

namespace PowerUtils.AspNetCore.ErrorHandler
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
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
