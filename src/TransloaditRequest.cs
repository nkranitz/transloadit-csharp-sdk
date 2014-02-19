namespace Transloadit
{
    /// <summary>
    /// Uses Transloadit services
    /// </summary>
    public class TransloaditRequest : ApiRequest
    {
        #region Public constants

        /// <summary>
        /// Default absolute URI path of assembly requests
        /// </summary>
        public const string AssemblyRoot = "/assemblies";

        /// <summary>
        /// Default absolute URI path to request bored instanc
        /// </summary>
        public const string BoredInstancePath = "/instances/bored";

        /// <summary>
        /// Default host of Transloadit services
        /// </summary>
        public const string DefaultHost = "api2.transloadit.com";

        /// <summary>
        /// Default protocol of Transloadit services
        /// </summary>
        public const string DefaultScheme = "http://";

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new TransloaditRequest object; sets the Host to the default one, also sets the path to AssemblyRoot
        /// </summary>
        public TransloaditRequest()
            : base()
        {
            Scheme = DefaultScheme;
            Host = DefaultHost;
            Path = AssemblyRoot;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Executes the current requests and gets the result
        /// </summary>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        new public TransloaditResponse Execute()
        {
            IApiResponse response = base.Execute();
            string responseString = response.ResponseString;
            return new TransloaditResponse(responseString);
        }

        #endregion
    }
}
