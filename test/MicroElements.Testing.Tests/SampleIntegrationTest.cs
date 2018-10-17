using FluentAssertions;
using MicroElements.Testing.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace MicroElements.Testing.Tests
{
    public class SampleIntegrationTest : IntegrationTest<SampleIntegrationTest, SampleTestConfiguration>
    {
        /// <inheritdoc />
        public SampleIntegrationTest(ConfigurationProvider<SampleIntegrationTest, SampleTestConfiguration> provider, ITestOutputHelper outputHelper) : base(provider, outputHelper)
        {
        }

        [Fact]
        public void SampleTest()
        {
            Output.WriteLine("SampleTest started");
            
            ConfigurationProvider.Configuration["Environment"].Should().Be("dev");
            ConfigurationProvider.TestConfiguration.Environment.Should().Be("dev");
            ConfigurationProvider.TestConfiguration.Host.Should().Be("http://google.com");
        }
    }
}
