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
    public class ConfigurationProvider<TTest, TConfiguration> : IDisposable
        where TConfiguration : ITestConfiguration, new()
    {
        public IConfiguration Configuration { get; }
        public TConfiguration TestConfiguration { get; }
        public string CommandLine { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationProvider{TTest, TConfiguration}"/> class.
        /// </summary>
        public ConfigurationProvider()
        {
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("Environment", "dev"), })
                .AddEnvironmentVariables()
                .Build();

            TestConfiguration = new TConfiguration();
            Configuration.Bind(TestConfiguration);

            var assemblyName = typeof(TTest).Assembly.GetName().Name;
            var settingsFileName = $"TestConfiguration/{assemblyName}.{TestConfiguration.Environment}.json";

            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("Environment", "dev"), })
                .AddJsonFile($"{settingsFileName}")
                .AddEnvironmentVariables()
                .Build();

            TestConfiguration = new TConfiguration();
            Configuration.Bind(TestConfiguration);

            CommandLine = Environment.CommandLine;
        }

        public void InitializeOnce()
        {

        }

        public void Dispose()
        {
        }
    }
}
