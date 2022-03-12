using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FirstAzureFunction.Models;
using FirstAzureFunction.Services;

namespace FirstAzureFunction
{
    public class FirstHTTPTrigger
    {
        private readonly IUserService _userService;
        public FirstHTTPTrigger(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "httpTrigger")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];       

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Function2")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "httpTrigger")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            UserE data = JsonConvert.DeserializeObject<UserE>(requestBody);            

            string responseMessage = string.IsNullOrEmpty(data.name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : _userService.Greetings(data);

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Function3")]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "httpTrigger")] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
