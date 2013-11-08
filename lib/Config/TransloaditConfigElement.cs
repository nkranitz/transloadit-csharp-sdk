using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Transloadit.Config
{
    /// <summary>
    /// Represents a Transloadit configuration element
    /// </summary>
    public class TransloaditConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Name (key) of the current config element
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return ((string)(base["name"])); }
        }

        /// <summary>
        /// Public authentication key of the current Transloadit confguration 
        /// </summary>
        [ConfigurationProperty("auth-key", IsKey = false, IsRequired = false)]
        public string AuthKey
        {
            get { return ((string)(base["auth-key"])); }
        }

        /// <summary>
        /// Secret authentication key of the current Transloadit confguration 
        /// </summary>
        [ConfigurationProperty("auth-secret", IsKey = false, IsRequired = false)]
        public string AuthSecret
        {
            get { return ((string)(base["auth-secret"])); }
        }

        /// <summary>
        /// Valid time period (in minutes) of a Transloadit request in the current configuration
        /// </summary>
        [ConfigurationProperty("auth-expire", DefaultValue = "120", IsKey = false, IsRequired = false)]
        public string AuthExpire
        {
            get { return (string)(base["auth-expire"]); }
        }

        /// <summary>
        /// Usage of bored instance flag
        /// </summary>
        [ConfigurationProperty("use-bored-instance", DefaultValue = "true", IsKey = false, IsRequired = false)]
        public string UseBoredInstance
        {
            get { return (string)(base["use-bored-instance"]); }
        }

        /// <summary>
        /// Gets the default template ID
        /// </summary>
        [ConfigurationProperty("default-template-id", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string DefaultTemplateID
        {
            get { return (string)(base["default-template-id"]); }
        }
    }
}
