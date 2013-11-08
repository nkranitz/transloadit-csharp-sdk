using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transloadit.Config.Exceptions
{
    /// <summary>
    /// Thrown when the specified config is not found
    /// </summary>
    public class ConfigNotFoundException : Exception
    {
        #region Constructors

        public ConfigNotFoundException(string config)
                    : base("Transloadit config is not found: " + config)
        {

        }

        #endregion
    }
}
