using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Config;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Utils;
using Xunit;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.ControllersTests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class TestsControllerTests
    {
        private readonly IntegrationTestsFixture _testsFixture;

        public TestsControllerTests(IntegrationTestsFixture testsFixture)
            => _testsFixture = testsFixture;


        [Fact]
        public async Task WithError_Validate_400()
        {
            // Arrange
            var requestUri = "/test/true";


            // Act
            (var response, var content) = await _testsFixture.Client.SendGetAsync<ErrorProblemDetails>(requestUri);


            // Assert
            response.ValidateResponse(HttpStatusCode.BadRequest);
            response.ValidateContentTypeProblemJson();
            content.ValidateContent(
                HttpStatusCode.BadRequest,
                "GET: " + requestUri,
                new Dictionary<string, ErrorDetails>()
                {
                    ["demoProp"] = new("DemoCode", "One validation error occurred.")
                }
            );
        }

        [Fact]
        public async Task WithoutError_Validate_200()
        {
            // Arrange
            var requestUri = "/test/false";


            // Act
            (var response, var _) = await _testsFixture.Client.SendGetAsync<string>(requestUri);


            // Assert
            response.ValidateResponse(HttpStatusCode.OK);
        }
    }
}
