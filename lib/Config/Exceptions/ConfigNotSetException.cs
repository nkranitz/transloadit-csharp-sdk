using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transloadit.Config.Exceptions
{
    /// <summary>
    /// Thrown when config was not set for Transloadit object
    /// </summary>
    public class ConfigNotSetException : Exception
    {
        #region Constructors

        public ConfigNotSetException()
            : base("Config is not set")
        {

        }

        #endregion
    }
}
