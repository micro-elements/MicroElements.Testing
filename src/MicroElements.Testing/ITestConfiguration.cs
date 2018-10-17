namespace MicroElements.Testing
{
    /// <summary>
    /// Base interface for test configurations.
    /// </summary>
    public interface ITestConfiguration
    {
        /// <summary>
        /// Gets or sets configuration path. Can be relative or absolute.
        /// </summary>
        string ConfigurationPath { get; set; }

        /// <summary>
        /// Gets or sets configuration profile.
        /// Can be hierarchical. For example: 'Profile/SubProfile'.
        /// </summary>
        string Profile { get; set; }
    }
}
