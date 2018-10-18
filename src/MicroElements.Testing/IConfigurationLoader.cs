using Microsoft.Extensions.Configuration;

namespace MicroElements.Testing
{
    /// <summary>
    /// Provides methods to initialize configuration.
    /// </summary>
    public interface IConfigurationLoader
    {
        /// <summary>
        /// Initializes configuration.
        /// </summary>
        /// <param name="testStartupConfiguration">Test startup configuration.</param>
        /// <returns>Loaded and builded configuration.</returns>
        IConfiguration InitializeConfiguration(ITestStartupConfiguration testStartupConfiguration);
    }
}
