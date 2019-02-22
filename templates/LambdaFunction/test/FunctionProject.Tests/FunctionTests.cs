using System.Threading.Tasks;
using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;
using FluentAssertions;
using Xunit;

namespace Function.Tests
{
    public class FunctionTests
    {
        [Fact]
        public async Task DoesNotThrowWhenInvoked()
        {
            var exception = await Record.ExceptionAsync(() => new Function().FunctionHandlerAsync(new SQSEvent(), new TestLambdaContext()));

            exception.Should().BeNull();
        }
    }
}
