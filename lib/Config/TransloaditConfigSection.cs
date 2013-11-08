using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Transloadit.Config
{
    /// <summary>
    /// Stores and handles Transloadit configuration values from the application configuration file
    /// </summary>
    public class TransloaditConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the available Transloadit configs
        /// </summary>
        [ConfigurationProperty("transloadit-configs")]
        public TransloaditConfigCollection TransloaditConfigs
        {
            get { return ((TransloaditConfigCollection)(base["transloadit-configs"])); }
            set { base["transloadit-configs"] = value; }
        }

        /// <summary>
        /// Gets the log confguration for Transloadit
        /// </summary>
        [ConfigurationProperty("log")]
        public TransloaditLogConfigElement TransloaditLogConfig
        {
            get { return ((TransloaditLogConfigElement)(base["log"])); }
            set { base["log"] = value; }
        }
    }
}
