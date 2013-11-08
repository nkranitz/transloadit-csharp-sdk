using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Transloadit.Config
{
    /// <summary>
    /// Collects available Transloadit configurations
    /// </summary>
    [ConfigurationCollection(typeof(TransloaditConfigElement))]
    public class TransloaditConfigCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Creates new Transloadit config element
        /// </summary>
        /// <returns>Created Transloadit config element</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new TransloaditConfigElement();
        }

        /// <summary>
        /// Gets the name of Transloadit config element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TransloaditConfigElement)(element)).Name;
        }

        /// <summary>
        /// Gets a Transloadit config element from the collection by the specified index
        /// </summary>
        /// <param name="index">Index of the required config element</param>
        /// <returns>Transloadit config element</returns>
        public TransloaditConfigElement this[string index]
        {
            get { return (TransloaditConfigElement)BaseGet(index); }
        }
    }
}
