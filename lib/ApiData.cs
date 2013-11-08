using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit
{
    /// <summary>
    /// Stores information which can be sent via an HTTP request
    /// </summary>
    public class ApiData
    {
        #region Public properties

        /// <summary>
        /// Gets and sets data fields of a request (key - value pairs)
        /// </summary>
        public Dictionary<string, object> Fields { get; set; }

        /// <summary>
        /// Gets and sets the path list of the files which will be sent
        /// </summary>
        public Dictionary<string, string> Files { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates new ApiData object; sets Fields and Files to empty collections
        /// </summary>
        public ApiData()
        {
            Fields = new Dictionary<string, object>();
            Files = new Dictionary<string, string>();
        }

        #endregion
    }
}
