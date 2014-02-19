using System.Collections.Generic;

namespace Transloadit.Assembly
{
    /// <summary>
    /// Defines the major functionality of Transloadit step
    /// </summary>
    public interface IStep
    {
        /// <summary>
        /// Sets an option for a step in the assembly
        /// </summary>
        /// <param name="key">Name of the option</param>
        /// <param name="value">Value of the pption</param>
        void SetOption(string key, object value);

        /// <summary>
        /// Gets the current step as dictionary
        /// </summary>
        /// <returns>Step dictionary</returns>
        Dictionary<string, object> ToDictionary();
    }
}
