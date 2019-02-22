using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Kralizek.Lambda;
using Microsoft.Extensions.Logging;

namespace Function
{
    public class Handler : IRequestResponseHandler<APIGatewayProxyRequest, APIGatewayProxyResponse>
    {
        private readonly ILogger<Handler> _logger;

        public Handler(ILogger<Handler> logger) => _logger = logger;

        public Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest input, ILambdaContext context)
        {
            _logger.LogInformation("Function invoked for path {Path}", input.Path);
            return Task.FromResult(new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = "Hello World!",
                Headers = new Dictionary<string, string> {["content-type"] = "text/plain"},
                IsBase64Encoded = false
            });
        }
    }
}
