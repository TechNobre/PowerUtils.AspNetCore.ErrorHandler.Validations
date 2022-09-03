using PowerUtils.Validations;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Samples.Services
{
    public interface ITestService
    {
        string GetResult(bool value);
    }


    public class TestService : ITestService
    {
        private readonly IValidationNotifications _validations;

        public TestService(IValidationNotifications validations)
            => _validations = validations;

        public string GetResult(bool value)
        {
            if(value)
            {
                _validations.AddBadNotification("DemoProp", "DemoCode");
                return default;
            }

            return "true";
        }
    }
}
