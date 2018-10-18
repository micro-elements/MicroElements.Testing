using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.XUnit
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    /// <typeparam name="TTest">Type of real test class.</typeparam>
    /// <typeparam name="TConfiguration">Type of configuration.</typeparam>
    /// <typeparam name="TConfigurationLoader">Configuration loader.</typeparam>
    public class IntegrationTest<TTest, TConfiguration, TConfigurationLoader> : IClassFixture<ConfigurationProvider<TTest, TConfiguration, TConfigurationLoader>>
        where TConfiguration : new()
        where TConfigurationLoader : IConfigurationLoader, new()
    {
        /// <summary>
        /// Test output.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Gets test configuration provider.
        /// </summary>
        protected IConfigurationProvider<TConfiguration> ConfigurationProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest{TTest, TConfiguration, TConfigurationLoader}"/> class.
        /// </summary>
        /// <param name="provider">Configuration provider.</param>
        /// <param name="outputHelper">XUnit test output.</param>
        public IntegrationTest(ConfigurationProvider<TTest, TConfiguration, TConfigurationLoader> provider, ITestOutputHelper outputHelper)
        {
            Output = outputHelper;
            ConfigurationProvider = provider;
        }
    }
}
