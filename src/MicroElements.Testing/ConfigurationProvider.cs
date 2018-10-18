using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MicroElements.Testing
{
    /// <summary>
    /// Provides configuration for test.
    /// </summary>
    /// <typeparam name="TTest">Real test type.</typeparam>
    /// <typeparam name="TConfiguration">Configuration type.</typeparam>
    /// <typeparam name="TConfigurationLoader">Real configuration loader.</typeparam>
    public class ConfigurationProvider<TTest, TConfiguration, TConfigurationLoader> : IConfigurationProvider<TConfiguration>, IDisposable
        where TConfiguration : new()
        where TConfigurationLoader : IConfigurationLoader, new()
    {
        /// <inheritdoc />
        public ITestStartupConfiguration TestStartupConfiguration { get; private set; }

        /// <inheritdoc />
        public TConfiguration TestConfiguration { get; private set; }

        /// <inheritdoc />
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationProvider{TTest, TConfiguration, TConfigurationLoader}"/> class.
        /// </summary>
        public ConfigurationProvider()
        {
            // Startup configuration
            TestStartupConfiguration = InitializeTestStartupConfiguration();

            // Main configuration
            Configuration = new TConfigurationLoader().InitializeConfiguration(TestStartupConfiguration);

            // Typed configuration
            TestConfiguration = new TConfiguration();
            Configuration.Bind(TestConfiguration);
        }

        private static ITestStartupConfiguration InitializeTestStartupConfiguration()
        {
            var startupConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(ITestStartupConfiguration.ConfigurationPath), "TestConfiguration"),
                    new KeyValuePair<string, string>(nameof(ITestStartupConfiguration.Profile), "dev"),
                })
                .AddEnvironmentVariables()
                .Build();

            var testStartupConfiguration = new TestStartupConfiguration();
            testStartupConfiguration.TestType = typeof(TTest);
            startupConfiguration.Bind(testStartupConfiguration);
            return testStartupConfiguration;
        }

        public void InitializeOnce()
        {
        }

        public void Dispose()
        {
        }
    }
}
