using System.Collections.Generic;

namespace Transloadit.Assembly
{
    /// <summary>
    /// Represents a Transloadit step
    /// </summary>
    public class Step : IStep
    {
        #region Protected attributes

        /// <summary>
        /// Stores the options of the current step
        /// </summary>
        protected Dictionary<string, object> options;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new step
        /// </summary>
        public Step()
        {
            options = new Dictionary<string, object>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Sets an option for a step in the assembly
        /// </summary>
        /// <param name="key">Name of the option</param>
        /// <param name="value">Value of the pption</param>
        public void SetOption(string key, object value)
        {
            options.Add(key, value);
        }

        /// <summary>
        /// Gets the current step as dictionary
        /// </summary>
        /// <returns>Step dictionary</returns>
        public Dictionary<string, object> ToDictionary()
        {
            return options;
        }

        #endregion
    }
}
