using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PowerUtils.Validations;

namespace PowerUtils.AspNetCore.ErrorHandler
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public class ValidationNotificationsFilter : IAsyncResultFilter
    {
        private readonly IValidationNotifications _validations;
        private readonly IProblemFactory _factory;

        public ValidationNotificationsFilter(
            IValidationNotifications validations,
            IProblemFactory factory
        )
        {
            _validations = validations;
            _factory = factory;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if(_validations.Invalid)
            {
                context.HttpContext.Response.StatusCode = (int)_validations.StatusCode;
                context.HttpContext.Response.ContentType = ProblemDetailsDefaults.PROBLEM_MEDIA_TYPE_JSON;

                var errors = _validations.Notifications
                    .ToDictionary(
                        k => k.Property,
                        v => new ErrorDetails
                        {
                            Code = v.ErrorCode,
                            Description = "One validation error occurred."
                        }
                    );

                var response = _factory.CreateProblem(errors: errors);

                await context.HttpContext.Response.WriteAsync(response);

                return;
            }

            await next();
        }
    }
}
