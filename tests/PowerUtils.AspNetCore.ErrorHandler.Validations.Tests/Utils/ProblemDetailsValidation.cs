using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Utils
{
    public static class ProblemDetailsValidation
    {
        public static void ValidateContent(this ErrorProblemDetails problemDetails, HttpStatusCode statusCode)
            => problemDetails.ValidateContent(statusCode, null);

        public static void ValidateContent(this ErrorProblemDetails problemDetails, HttpStatusCode statusCode, string instance)
        {
            var code = (int)statusCode;

            problemDetails.Status.Should()
                .Be(code);

            problemDetails.Type.Should()
                .NotBeNullOrWhiteSpace();

            problemDetails.Title.Should()
                .Be(ReasonPhrases.GetReasonPhrase(code));

            problemDetails.Instance.Should()
                .Be(instance);

            problemDetails.TraceId.Should()
                .NotBeNullOrWhiteSpace();
        }

        public static void ValidateContent(this ErrorProblemDetails problemDetails, HttpStatusCode statusCode, string instance, Dictionary<string, ErrorDetails> expectedErrors)
        {
            problemDetails.ValidateContent(statusCode, instance);

            foreach(var error in problemDetails.Errors)
            {
                expectedErrors[error.Key].Code.Should()
                    .Be(error.Value.Code);

                expectedErrors[error.Key].Description.Should()
                    .Be(error.Value.Description);
            }

            problemDetails.Errors.Should()
                .HaveCount(expectedErrors.Count);
        }

        public static void ValidateResponse(this HttpResponseMessage response, HttpStatusCode statusCode)
            => response.ValidateStatusCode(statusCode);

        public static void ValidateStatusCode(this HttpResponseMessage response, HttpStatusCode statusCode)
            => response.StatusCode.Should()
                .Be(statusCode);

        public static void ValidateContentTypeProblemJson(this HttpResponseMessage response)
            => response.Content.Headers.ContentType.MediaType.Should()
                .Be(ProblemDetailsDefaults.PROBLEM_MEDIA_TYPE_JSON);

        public static void ValidateContentTypeApplicationJson(this HttpResponseMessage response)
            => response.Content.Headers.ContentType.MediaType.Should()
                .Be(MediaTypeNames.Application.Json);
    }
}
