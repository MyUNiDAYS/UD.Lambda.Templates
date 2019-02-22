using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Kralizek.Lambda;
using Microsoft.Extensions.Logging;

namespace Function
{
    public class Handler : IEventHandler<SQSEvent>
    {
        private readonly ILogger<Handler> _logger;

        public Handler(ILogger<Handler> logger) => _logger = logger;

        public Task HandleAsync(SQSEvent input, ILambdaContext context)
        {
            _logger.LogInformation("Function invoked with {EventType}", input.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
