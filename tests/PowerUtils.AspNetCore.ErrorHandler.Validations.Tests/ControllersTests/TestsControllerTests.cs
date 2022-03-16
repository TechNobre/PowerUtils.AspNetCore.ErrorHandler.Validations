using System.Net;
using System.Threading.Tasks;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Config;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Utils;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.ControllersTests;

[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class TestsControllerTests
{
    private readonly IntegrationTestsFixture _testsFixture;

    public TestsControllerTests(IntegrationTestsFixture testsFixture)
        => _testsFixture = testsFixture;


    [Fact]
    public async Task Validations_WithError_400()
    {
        // Arrange
        var requestUri = "/test/true";


        // Act
        (var response, var content) = await _testsFixture.Client.SendGetAsync<ProblemDetailsResponse>(requestUri);


        // Assert
        response.ValidateResponse(HttpStatusCode.BadRequest);
        response.ValidateContentTypeProblemJson();
        content.ValidateContent(
            HttpStatusCode.BadRequest,
            "GET: " + requestUri,
            new()
            {
                { "demoProp", "DemoCode" }
            }
        );
    }

    [Fact]
    public async Task Validations_WithoutError_200()
    {
        // Arrange
        var requestUri = "/test/false";


        // Act
        (var response, var _) = await _testsFixture.Client.SendGetAsync<string>(requestUri);


        // Assert
        response.ValidateResponse(HttpStatusCode.OK);
    }
}
