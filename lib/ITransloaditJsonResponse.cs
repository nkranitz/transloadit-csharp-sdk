using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transloadit
{
    /// <summary>
    /// Interface for transloadit JSON response handler
    /// </summary>
    interface ITransloaditJsonResponse
    {
        /// <summary>
        /// Gets and sets quality of the response
        /// </summary>
        TransloaditResponse.Quality ResponseQuality { get; }

        /// <summary>
        /// Tries to parse the sent JSON string into the Data tree, sets quality information about the response
        /// </summary>
        void ParseJsonResponseString();
    }
}
