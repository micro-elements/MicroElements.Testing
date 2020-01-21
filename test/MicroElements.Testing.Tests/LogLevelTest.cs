using MicroElements.Testing.XUnit.Logging;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.Tests
{
    public class LogLevelTest
    {
        private readonly ILogger _logger;

        public LogLevelTest(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = TestLoggerFactory.CreateXUnitLoggerProvider(testOutputHelper, LogLevel.Information);
            _logger = loggerFactory.CreateLogger("InformationLogger");
        }


        [Fact]
        public void MinLogLevelTest()
        {
            _logger.LogTrace("Hello from Trace");
            _logger.LogDebug("Hello from Debug");
            _logger.LogInformation("Hello from Information");
            _logger.LogWarning("Hello from Warning");
            _logger.LogError("Hello from Error");
        }
    }
}
