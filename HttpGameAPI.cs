using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Game.Function;

    public class HttpGameAPI
    {
        private readonly ILogger<HttpGameAPI> _logger;

        public HttpGameAPI(ILogger<HttpGameAPI> logger)
        {
            _logger = logger;
        }

        [Function("Welcome")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }

