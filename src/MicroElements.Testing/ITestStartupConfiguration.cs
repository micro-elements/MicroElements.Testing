using System;

namespace MicroElements.Testing
{
    /// <summary>
    /// Base interface for test configurations.
    /// </summary>
    public interface ITestStartupConfiguration
    {
        /// <summary>
        /// Gets configuration path. Can be relative or absolute.
        /// </summary>
        string ConfigurationPath { get; }

        /// <summary>
        /// Gets configuration profile.
        /// Can be hierarchical. For example: 'Profile/SubProfile'.
        /// </summary>
        string Profile { get; }

        /// <summary>
        /// Gets test method type.
        /// </summary>
        Type TestType { get; }
    }
}
