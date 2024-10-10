using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TestAzureFunction.Services;

namespace TestAzureFunction
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IServiceTest _serviceTest;

        public Function1(ILogger<Function1> logger, IServiceTest serviceTest)
        {
            _logger = logger;
            _serviceTest=serviceTest;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var res = _serviceTest.isTrue("jose");
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
