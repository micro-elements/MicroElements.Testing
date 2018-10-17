namespace MicroElements.Testing
{
    /// <summary>
    /// Base interface for test configurations.
    /// </summary>
    public interface ITestConfiguration
    {
        /// <summary>
        /// Gets environment.
        /// </summary>
        string Environment { get; set; }
    }
}
