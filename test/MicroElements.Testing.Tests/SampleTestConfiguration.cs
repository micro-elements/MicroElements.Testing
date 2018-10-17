namespace MicroElements.Testing.Tests
{
    public class SampleTestConfiguration : ITestConfiguration
    {
        /// <inheritdoc />
        public string Environment { get; set; }

        /// <summary>
        /// Host for integration test.
        /// </summary>
        public string Host { get; set; }
    }
}
