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
        /// Success of the current request
        /// </summary>
        protected bool success;

        #endregion

        #region Public properties

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
