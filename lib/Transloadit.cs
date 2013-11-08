using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;

using Transloadit.Config;
using Transloadit.Assembly;

namespace Transloadit
{
    /// <summary>
    /// Handles whole data transfer procedures between Your Application and Transloadit 
    /// </summary>
    public class Transloadit : ITransloadit
    {
        #region Protected constants

        /// <summary>
        /// Name of the default Transloadit config
        /// </summary>
        protected const string DefaultConfigName = "default";

        #endregion

        #region Protected attributes

        /// <summary>
        /// Transloadit config instance
        /// </summary>
        protected TransloaditConfigElement config;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the created config instance
        /// </summary>
        public TransloaditConfigElement Config
        {
            get
            {
                return config;
            }
        }

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
        /// Creates a new Transloadit object, initializates the related configs and sets the major authentication information
        /// </summary>
        /// <param name="configName">Name of the required config</param>
        /// <exception cref="Transloadit.Config.Exceptions.ConfigNotFoundException">
        /// Thrown when the required configuration is not set in the current application config
        /// </exception>
        public Transloadit(string configName = Transloadit.DefaultConfigName)
        {
            SetConfigByName(configName);
            if (Config == null)
            {
                throw new Config.Exceptions.ConfigNotFoundException(configName);
            }
            Key = Config.AuthKey;
            Secret = Config.AuthSecret;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tries to delete an assembly by the specified assembly ID.
        /// </summary>
        /// <param name="assemblyID">ID of the assembly which will be tried to be deleted</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        /// <exception cref="Transloadit.Config.Exceptions.ConfigNotSetException">
        /// Thrown when the config is not set before invoke an assembly
        /// </exception>
        public TransloaditResponse DeleteAssembly(string assemblyID)
        {
            if (config == null)
            {
                throw new Config.Exceptions.ConfigNotSetException();
            }

            TransloaditRequest request = Request();
            request.Host += "/" + assemblyID;
            TransloaditResponse response = request.Execute();

            if (response.Success)
            {
                Uri uri = new Uri((string)response.Data["assembly_url"]);
                TransloaditRequest deleteRequest = Request();
                deleteRequest.Method = TransloaditRequest.RequestMethod.Delete;
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
        /// <exception cref="Transloadit.Config.Exceptions.ConfigNotSetException">
        /// Thrown when the config is not set before invoke an assembly
        /// </exception>
        public TransloaditResponse InvokeAssembly(IAssemblyBuilder assembly)
        {
            if (config == null)
            {
                throw new Config.Exceptions.ConfigNotSetException();
            }

            TransloaditRequest request = Request();
            assembly.SetAuthKey(Key);

            bool useBoredInstance = false;
            bool.TryParse(Config.UseBoredInstance, out useBoredInstance);
            if (useBoredInstance)
            {
                request.Method = TransloaditRequest.RequestMethod.Get;
                request.Path = TransloaditRequest.BoredInstancePath;

                TransloaditResponse boredInstance = (TransloaditResponse)RequestAndExecute(request);

                if (boredInstance.Success)
                {
                    request.Host = (string)boredInstance.Data["api2_host"];
                }
            }

            request.Method = TransloaditRequest.RequestMethod.Post;
            request.Path = TransloaditRequest.AssemblyRoot;

            DateTime expirationDateTime = DateTime.UtcNow;

            double expirationMinutes = 120;
            double.TryParse(Config.AuthExpire, out expirationMinutes);
            expirationDateTime = expirationDateTime.AddMinutes(expirationMinutes);
            assembly.SetAuthExpires(expirationDateTime);

            if (Config.DefaultTemplateID.Length > 0 && !assembly.HasTemplateID())
            {
                assembly.SetTemplateID(Config.DefaultTemplateID);
            }

            string paramValue = (string)assembly.ToJsonString();
            string signatureValue = GetSignature(paramValue);

            request.Data = assembly.ToApiData();
            request.Data.Fields.Add("signature", signatureValue);

            return request.Execute();
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

        #region Protected methods

        /// <summary>
        /// Sets the cnfig for the current Transloadit instance by name
        /// </summary>
        /// <param name="configName">Name of the config</param>
        protected void SetConfigByName(string configName)
        {
            config = TransloaditConfig.Config.TransloaditConfigs[configName];
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
