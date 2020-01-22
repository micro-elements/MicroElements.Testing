using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MicroElements.Testing.XUnit.Logging
{
    /// <summary>
    /// <see cref="ILoggerProvider"/> for XUnit.
    /// </summary>
    public class XUnitLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _output;
        private readonly LogLevel _minLogLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="XUnitLoggerProvider"/> class.
        /// </summary>
        /// <param name="output">Test output.</param>
        /// <param name="minLogLevel">Minimal log level.</param>
        public XUnitLoggerProvider(ITestOutputHelper output, LogLevel minLogLevel = LogLevel.Trace)
        {
            _output = output;
            _minLogLevel = minLogLevel;
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return new XUnitLogger(_output, _minLogLevel);
        }
    }
}
