using System;

using Transloadit.Assembly;

namespace Transloadit
{
    /// <summary>
    /// Handles whole data transfer procedures between Your Application and Transloadit 
    /// </summary>
    public class Transloadit : ITransloadit
    {
        #region Public properties

        /// <summary>
        /// Gets and sets API Key of the current Transloadit user. This key is used for each Transloadit request
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets and sets API Secret code of the current Transloadit user. This code is used for each request if signature authentication is enabled 
        /// </summary>
        public string Secret { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new Transloadit object with the passed keys
        /// </summary>
        /// <param name="key">Public authentication key</param>
        /// <param name="secret">Secret authorization key</param>
        public Transloadit(string key, string secret)
        {
            Key = key;
            Secret = secret;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tries to delete an assembly by the specified assembly ID.
        /// </summary>
        /// <param name="assemblyID">ID of the assembly which will be tried to be deleted</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        public TransloaditResponse DeleteAssembly(string assemblyID)
        {
            TransloaditRequest request = Request();
            request.Host += "/" + assemblyID;
            TransloaditResponse response = request.Execute();

            if (response.Success)
            {
                Uri uri = new Uri((string)response.Data["assembly_url"]);
                TransloaditRequest deleteRequest = Request();
                deleteRequest.Method = ApiRequestMethods.RequestMethod.Delete;
                deleteRequest.Host = uri.Host;
                deleteRequest.Path = uri.AbsolutePath;
                TransloaditResponse deleteResponse = request.Execute();

                return deleteResponse;
            }

            return null;
        }

        /// <summary>
        /// Tries to create the specified assembly on Transloadit. Bored instance is requested at first. If there is one, then it will
        /// be used to proceed the request, which can be completed on a bored instance.
        /// </summary>
        /// <param name="assembly">Specified assembly which will be tried to be created.
        /// Please use TransloaditAssemblyBuilder to create a new assembly</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        public TransloaditResponse InvokeAssembly(IAssemblyBuilder assembly)
        {
            TransloaditRequest request = Request();
            assembly.SetAuthKey(Key);

            request.Method = ApiRequestMethods.RequestMethod.Get;
            request.Path = TransloaditRequest.BoredInstancePath;

            TransloaditResponse boredInstance = (TransloaditResponse)RequestAndExecute(request);

            string host = request.Host;
            if (boredInstance.Success)
            {
                host = (string)boredInstance.Data["api2_host"];
            }

            TransloaditRequest invokeRequest = Request();
            invokeRequest.Host = host;
            invokeRequest.Method = ApiRequestMethods.RequestMethod.Post;
            invokeRequest.Path = TransloaditRequest.AssemblyRoot;

            DateTime expirationDateTime = DateTime.UtcNow;

            double expirationMinutes = 120;
            expirationDateTime = expirationDateTime.AddMinutes(expirationMinutes);
            assembly.SetAuthExpires(expirationDateTime);

            string paramValue = (string)assembly.ToJsonString();
            string signatureValue = GetSignature(paramValue);

            invokeRequest.Data = assembly.ToApiData();
            invokeRequest.Data.Fields.Add("signature", signatureValue);

            return invokeRequest.Execute();
        }

        /// <summary>
        /// Creates and gets a new TransloaditRequest instance with default attributes
        /// </summary>
        /// <returns>TransloaditRequest instance with default attributes</returns>
        public TransloaditRequest Request()
        {
            return new TransloaditRequest();
        }

        /// <summary>
        /// Creates then tries to proceed the specified or a default request, then executes this and gets the response of it.
        /// </summary>
        /// <param name="request">Optional request which will be tried to be executed</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        public TransloaditResponse RequestAndExecute(TransloaditRequest request = null)
        {
            if (request == null)
            {
                request = Request();
            }
            return (TransloaditResponse)request.Execute();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Generates and gets the signature of the current request (based on the API Secret code and "params" field)
        /// </summary>
        /// <param name="param">Specified "params" field of the current Transloadit request</param>
        /// <returns>SHA1 signature for the current request</returns>
        private string GetSignature(string str)
        {
            if (Secret == null || Secret.Length < 1)
            {
                return null;
            }
            return Utils.GetSha1(Secret, str);
        }

        #endregion
    }
}
