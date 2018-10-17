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
    public class ConfigurationProvider<TTest, TConfiguration> : IConfigurationProvider<TConfiguration>, IDisposable
        where TConfiguration : ITestConfiguration, new()
    {
        /// <inheritdoc />
        public TConfiguration TestConfiguration { get; }

        /// <inheritdoc />
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationProvider{TTest, TConfiguration}"/> class.
        /// </summary>
        public ConfigurationProvider()
        {
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("Environment", "dev"), })
                .AddEnvironmentVariables()
                .Build();

            var conf = new TestConfiguration();
            Configuration.Bind(conf);
            string environment = conf.Environment;

            var assemblyName = typeof(TTest).Assembly.GetName().Name;
            var settingsFileName = $"TestConfiguration/{assemblyName}.{environment}.json";

            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("Environment", "dev"), })
                .AddJsonFile($"{settingsFileName}", optional: true)
                .AddEnvironmentVariables()
                .Build();

            TestConfiguration = new TConfiguration();
            Configuration.Bind(TestConfiguration);
        }

        public void InitializeOnce()
        {
        }

        public void Dispose()
        {
        }
    }
}
