using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MicroElements.Testing.XUnit.Logging
{
    /// <summary>
    /// Logger for XUnit output.
    /// </summary>
    public class XUnitLogger : ILogger
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="XUnitLogger"/> class.
        /// </summary>
        /// <param name="output">XUnit test output.</param>
        public XUnitLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = formatter(state, exception);
            string thread = Thread.CurrentThread.ManagedThreadId.ToString("000");
            var formattedMessage = $"[{thread}] | {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {message}";
            _output.WriteLine(formattedMessage);
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
