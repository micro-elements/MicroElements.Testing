using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MicroElements.Testing
{
    public class ConfigurationProvider<TTest, TConfiguration> : IDisposable
        where TConfiguration : ITestConfiguration, new()
    {
        public IConfiguration Configuration;
        public string CommandLine;
        public TConfiguration TestConfiguration;

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
