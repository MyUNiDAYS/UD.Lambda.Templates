using System;
using System.IO;
using Amazon.Lambda.APIGatewayEvents;
using Kralizek.Lambda;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Function
{
    public sealed class Function : RequestResponseFunction<APIGatewayProxyRequest, APIGatewayProxyResponse>
    {
        protected override void Configure(IConfigurationBuilder builder)
        {
            Console.WriteLine("Starting Configure");
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("Environment")?.ToLowerInvariant()}.json",
                    optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }

        protected override void ConfigureServices(IServiceCollection services, IExecutionEnvironment executionEnvironment)
        {
            // services.AddAWSService<IAmazonServiceClient>(Configuration.GetAWSOptions("AWS.Service"));

            RegisterHandler<Handler>(services);
        }

        protected override void ConfigureLogging(ILoggingBuilder logging, IExecutionEnvironment executionEnvironment) =>
            logging
                .AddLambdaLogger(Configuration, "Logging");
    }
}
