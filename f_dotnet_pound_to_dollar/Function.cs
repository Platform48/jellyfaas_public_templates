using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Converter
{
    public class ConvertGBPToUSD : IHttpFunction
    {
        private const double ExchangeRate = 0.79;
        private readonly ILogger<ConvertGBPToUSD> _logger;

        public ConvertGBPToUSD(ILogger<ConvertGBPToUSD> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            // Get the GBP amount from the request
            string gbpAmountStr = request.Query["gbp"];
            if (string.IsNullOrEmpty(gbpAmountStr))
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync("GBP amount is required.");
                return;
            }

            if (!double.TryParse(gbpAmountStr, out double gbpAmount))
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync("Invalid GBP amount.");
                return;
            }

            if (gbpAmount < 0)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync("GBP amount must be positive.");
                return;
            }

            // Calculate the USD amount
            double usdAmount = gbpAmount * ExchangeRate;

            // Return the USD amount
            var returnData = new ReturnData { USDAmount = usdAmount };
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status200OK;
            await response.WriteAsJsonAsync(returnData);
        }

        private class ReturnData
        {
            public double USDAmount { get; set; }
        }
    }
}
