using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using FluentAssertions;
using Xunit;

namespace Function.Tests
{
    public class FunctionTests
    {
        [Fact]
        public async Task ReturnsExpectedResponseForRequest()
        {
            var response = await new Function().FunctionHandlerAsync(new APIGatewayProxyRequest
            {
                Path = "/foo"
            }, new TestLambdaContext());

            response.Should().BeEquivalentTo(new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = "Hello World!",
                Headers = new Dictionary<string, string> {["content-type"] = "text/plain"}
            });
        }
    }
}
