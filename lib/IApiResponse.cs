using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit
{
    /// <summary>
    /// Interface for API response
    /// </summary>
    public interface IApiResponse
    {
        /// <summary>
        /// Gets the response string
        /// </summary>
        string ResponseString { get; }

        /// <summary>
        /// Gets data tree parsed from the sent response string
        /// </summary>
        Dictionary<string, object> Data { get; }

        /// <summary>
        /// Gets success information about the sent request
        /// </summary>
        bool Success { get; }
    }
}
