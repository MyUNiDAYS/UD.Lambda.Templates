using System;
using System.IO;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Kralizek.Lambda;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Function
{
    public sealed class Function : EventFunction<SQSEvent>
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
