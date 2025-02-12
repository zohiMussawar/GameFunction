using System.Net;
using GameFunction.Models.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Game.Function;

    public class HttpGameAPI
    {
        private readonly ILogger<HttpGameAPI> _logger;

        private readonly GamesContext _context;

        public HttpGameAPI(ILogger<HttpGameAPI> logger,GamesContext context)
        {
            _logger = logger;
            _context=context;
        }

        [Function("Welcome")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
        [Function("GetGames")]
public HttpResponseData GetGames(
[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "games")] HttpRequestData req)
{
    _logger.LogInformation("C# HTTP GET/posts trigger function processed a request in GetStudents().");

    var games = _context.Games.ToArray();

    var response = req.CreateResponse(HttpStatusCode.OK);
    response.Headers.Add("Content-Type", "application/json");

    response.WriteStringAsync(JsonConvert.SerializeObject(games));

    return response;
}

    }

