using Microsoft.AspNetCore.Mvc;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Samples.Services;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Samples.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _service;
        public TestController(ITestService service)
            => _service = service;

        [HttpGet("{value}")]
        public IActionResult Validations(bool value)
            => Ok(_service.GetResult(value));
    }
}
