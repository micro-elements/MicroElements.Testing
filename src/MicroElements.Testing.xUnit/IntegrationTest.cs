using System;
using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.xUnit
{
    public class IntegrationTest<TTest, TConfiguration> : IClassFixture<ConfigurationProvider<TTest, TConfiguration>> where TConfiguration : ITestConfiguration, new()
    {
        protected TConfiguration Configuration { get; }

        public IntegrationTest(ConfigurationProvider<TTest, TConfiguration> provider, ITestOutputHelper outputHelper)
        {
            Configuration = provider.TestConfiguration;
        }
    }
}
