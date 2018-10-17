using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MicroElements.Testing.XUnit.Logging
{
    public static class TestLoggerFactory
    {
        public static ILoggerFactory CreateXUnitLoggerProvider(ITestOutputHelper output)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XUnitLoggerProvider(output));
            return loggerFactory;
        }
    }
}
