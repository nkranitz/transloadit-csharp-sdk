using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Transloadit.Config
{
    /// <summary>
    /// Handles Transloadit configurations
    /// </summary>
    public static class TransloaditConfig
    {
        #region Private attributes

        /// <summary>
        /// Stores Transloadit configurations
        /// </summary>
        private static TransloaditConfigSection config;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets Transloadit configuration
        /// </summary>
        public static TransloaditConfigSection Config
        {
            get { return config; }
        }

        #endregion

        #region Initializator

        /// <summary>
        /// Initializates TransloaditConfig
        /// </summary>
        static TransloaditConfig()
        {
            config = (TransloaditConfigSection)ConfigurationManager.GetSection("transloadit");
        }

        #endregion
    }
}
