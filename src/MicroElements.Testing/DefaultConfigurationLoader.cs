using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MicroElements.Testing
{
    /// <summary>
    /// Loads $"{assemblyName}.json" then overrides values with $"{assemblyName}.{profile}.json".
    /// </summary>
    public class DefaultConfigurationLoader : IConfigurationLoader
    {
        /// <inheritdoc />
        public IConfiguration InitializeConfiguration(ITestStartupConfiguration testStartupConfiguration)
        {
            var assemblyName = testStartupConfiguration.TestType.Assembly.GetName().Name;
            var settingsBaseFileName = $"{assemblyName}.json";
            var settingsFileName = $"{assemblyName}.{testStartupConfiguration.Profile}.json";
            var settingsBaseFullFileName = string.IsNullOrWhiteSpace(testStartupConfiguration.ConfigurationPath) ? settingsBaseFileName : Path.Combine(testStartupConfiguration.ConfigurationPath, settingsBaseFileName);
            var settingsFullFileName = string.IsNullOrWhiteSpace(testStartupConfiguration.ConfigurationPath) ? settingsFileName : Path.Combine(testStartupConfiguration.ConfigurationPath, settingsFileName);

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>(nameof(ITestStartupConfiguration.Profile), "dev") })
                .AddJsonFile(settingsBaseFullFileName, optional: true)
                .AddJsonFile(settingsFullFileName, optional: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }
}
