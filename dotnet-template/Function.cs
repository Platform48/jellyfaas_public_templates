using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExampleProject
{
   public class Example : IHttpFunction
    {
        private readonly ILogger<Example> _logger;

        public Example(ILogger<Example> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            // Get the name from the request
            string name = request.Query["name"];
            if (string.IsNullOrEmpty(name))
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync("name is required.");
                return;
            }

            // Create the greeting message
            var greeting = "hello, " + name + "!";

            // Prepare the return data
            var returnData = new ReturnData { Greeting = greeting };

            // Set response content type and status code, and write the JSON response
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status200OK;
            await response.WriteAsJsonAsync(returnData);
        }

        private class ReturnData
        {
            public string Greeting { get; set; }
        }
    }
}
