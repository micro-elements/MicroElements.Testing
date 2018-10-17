using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.XUnit
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    /// <typeparam name="TTest">Type of real test class.</typeparam>
    /// <typeparam name="TConfiguration">Type of configuration.</typeparam>
    public class IntegrationTest<TTest, TConfiguration> : IClassFixture<ConfigurationProvider<TTest, TConfiguration>>
        where TConfiguration : ITestConfiguration, new()
    {
        /// <summary>
        /// Test output.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Test configuration provider.
        /// </summary>
        protected IConfigurationProvider<TConfiguration> ConfigurationProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest{TTest, TConfiguration}"/> class.
        /// </summary>
        /// <param name="provider">Configuration provider.</param>
        /// <param name="outputHelper">XUnit test output.</param>
        public IntegrationTest(ConfigurationProvider<TTest, TConfiguration> provider, ITestOutputHelper outputHelper)
        {
            Output = outputHelper;
            ConfigurationProvider = provider;
        }
    }
}
