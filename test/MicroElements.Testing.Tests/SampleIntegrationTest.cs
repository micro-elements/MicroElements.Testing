using FluentAssertions;
using MicroElements.Testing.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.Tests
{
    public class SampleIntegrationTest : IntegrationTest<SampleIntegrationTest, SampleTestConfiguration, DefaultConfigurationLoader>
    {
        /// <inheritdoc />
        public SampleIntegrationTest(ConfigurationProvider<SampleIntegrationTest, SampleTestConfiguration, DefaultConfigurationLoader> provider, ITestOutputHelper outputHelper) : base(provider, outputHelper)
        {
        }

        [Fact]
        public void SampleTest()
        {
            Output.WriteLine("SampleTest started");
            
            ConfigurationProvider.Configuration["Profile"].Should().Be("dev");
            ConfigurationProvider.TestStartupConfiguration.Profile.Should().Be("dev");
            ConfigurationProvider.TestConfiguration.Host.Should().Be("http://google.com");
        }
    }
}
