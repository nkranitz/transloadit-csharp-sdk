using System;
using System.ComponentModel;

using Transloadit.Log;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Transloadit
{
    /// <summary>
    /// Handles the whole functionality of Transloadit response handling
    /// </summary>
    public class TransloaditResponse : ApiResponse, ITransloaditJsonResponse
    {
        #region Private attributes

        /// <summary>
        /// Stores the parsed data tree
        /// </summary>
        private JObject data;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the parsed data tree
        /// </summary>
        public JObject Data { get { return data; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new TransloaditResponse object, parses JSON response string, sets the success of parse
        /// </summary>
        public TransloaditResponse(string responseString)
            : base(responseString)
        {
            success = ParseJsonResponseString();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tries to parse the sent JSON string into the Data tree.
        /// </summary>
        /// <returns>Success of parse</returns>
        public bool ParseJsonResponseString()
        {
            try
            {
                data = JObject.Parse(ResponseString);
                return true;
            }
            catch (Exception e)
            {
                LoggerFactory.GetLogger().LogError(this.GetType(), e, "Given string was not able to be parsed as JSON data: {0}", responseString);
                return false;
            }
        }

        #endregion
    }
}
