using System;

namespace MicroElements.Testing
{
    /// <summary>
    /// Basic <see cref="ITestStartupConfiguration"/> implementation.
    /// </summary>
    internal class TestStartupConfiguration : ITestStartupConfiguration
    {
        /// <inheritdoc />
        public string ConfigurationPath { get; set; }

        /// <inheritdoc />
        public string Profile { get; set; }

        /// <inheritdoc />
        public Type TestType { get; set; }
    }
}
