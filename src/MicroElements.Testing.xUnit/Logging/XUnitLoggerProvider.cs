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

        /// <summary>
        /// Initializes a new instance of the <see cref="XUnitLoggerProvider"/> class.
        /// </summary>
        /// <param name="output">Test output.</param>
        public XUnitLoggerProvider(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return new XUnitLogger(_output);
        }
    }
}
