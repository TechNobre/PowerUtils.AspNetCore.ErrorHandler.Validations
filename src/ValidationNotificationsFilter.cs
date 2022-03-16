using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PowerUtils.Net.Constants;
using PowerUtils.Validations;

namespace PowerUtils.AspNetCore.ErrorHandler
{
    public class ValidationNotificationsFilter : IAsyncResultFilter
    {
        private readonly IValidationNotifications _validations;
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ValidationNotificationsFilter(
            IValidationNotifications validations,
            ProblemDetailsFactory problemDetailsFactory
        )
        {
            _validations = validations;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if(_validations.Invalid)
            {
                context.HttpContext.Response.StatusCode = (int)_validations.StatusCode;
                context.HttpContext.Response.ContentType = ExtendedMediaTypeNames.ProblemApplication.JSON;

                var errors = _validations.Notifications
                    .ToDictionary(
                        key => key.Property,
                        code => code.ErrorCode
                    );

                var response = _problemDetailsFactory.Create(context.HttpContext, errors);

                await context.HttpContext.Response.WriteAsync(response);

                return;
            }

            await next();
        }
    }
}
