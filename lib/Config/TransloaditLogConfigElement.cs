using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Transloadit.Config
{
    /// <summary>
    /// Represents a Transloadit log configuration element
    /// </summary>
    public class TransloaditLogConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Name of the ITransloaditLogger implementation class
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return ((string)(base["type"])); }
            set { base["type"] = value; }
        }

        /// <summary>
        /// Name of the ITransloaditLogger implementation class
        /// </summary>
        [ConfigurationProperty("enabled", DefaultValue = "false", IsRequired = false)]
        public string Enabled
        {
            get { return (string)(base["enabled"]); }
            set { base["enabled"] = value; }
        }
    }
}
