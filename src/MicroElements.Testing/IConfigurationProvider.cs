using Microsoft.Extensions.Configuration;

namespace MicroElements.Testing
{
    /// <summary>
    /// Provides configuration for tests.
    /// </summary>
    /// <typeparam name="TConfiguration">Configuration type.</typeparam>
    public interface IConfigurationProvider<out TConfiguration>
    {
        /// <summary>
        /// Test startup configuration.
        /// </summary>
        ITestStartupConfiguration TestStartupConfiguration { get; }

        /// <summary>
        /// Typed test configuration.
        /// </summary>
        TConfiguration TestConfiguration { get; }

        /// <summary>
        /// Untyped test configuration.
        /// </summary>
        IConfiguration Configuration { get; }
    }
}
