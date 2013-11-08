using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit
{
    /// <summary>
    /// Stores information about a REST API response
    /// </summary>
    public class ApiResponse : IApiResponse
    {
        #region Private attributes

        /// <summary>
        /// Response string
        /// </summary>
        protected string responseString;

        /// <summary>
        /// Parsed response data
        /// </summary>
        protected Dictionary<string, object> data;

        /// <summary>
        /// Success of the current request
        /// </summary>
        protected bool success;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets data tree parsed from the sent response string
        /// </summary>
        public Dictionary<string, object> Data { get { return data; } }

        /// <summary>
        /// Gets the response string
        /// </summary>
        public string ResponseString { get { return responseString; } }

        /// <summary>
        /// Gets success information about the sent request
        /// </summary>
        public bool Success { get { return success; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Sets response string, parses response string
        /// </summary>
        /// <param name="responseString">Response string, respond by a server the server</param>
        public ApiResponse(string responseString)
        {
            this.responseString = responseString;
        }

        #endregion
    }
}
