using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.ComponentModel;

using Transloadit.Log;

namespace Transloadit
{
    /// <summary>
    /// Handles the whole functionality of Transloadit response handling
    /// </summary>
    public class TransloaditResponse : ApiResponse, ITransloaditJsonResponse
    {
        #region Public enums

        /// <summary>
        /// Response quality information
        /// </summary>
        public enum Quality
        {
            [DescriptionAttribute("INVALID_JSON_DATA")]
            InvalidJsonData,
            [DescriptionAttribute("VALID_JSON_DATA")]
            ValidJsonData
        }

        #endregion

        #region Protected attributes

        /// <summary>
        /// Quality of the current response
        /// </summary>
        protected Quality responseQuality;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets and sets quality of the response
        /// </summary>
        public Quality ResponseQuality { get { return responseQuality; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new TransloaditResponse object, parses JSON response string
        /// </summary>
        public TransloaditResponse(string responseString)
            : base(responseString)
        {
            ParseJsonResponseString();
            if (Data.ContainsKey("ok"))
            {
                success = true;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tries to parse the sent JSON string into the Data tree, sets quality information about the response
        /// </summary>
        public void ParseJsonResponseString()
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                data = js.Deserialize<Dictionary<string, object>>(ResponseString);
                responseQuality = Quality.ValidJsonData;
            }
            catch (Exception e)
            {
                LoggerFactory.GetLogger().LogError(this.GetType(), e, "Given string was not able to be parsed as JSON data: {0}", responseString);
                responseQuality = Quality.InvalidJsonData;                
            }
        }

        #endregion
    }
}
