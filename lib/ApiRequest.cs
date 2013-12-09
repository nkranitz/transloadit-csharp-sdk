using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Collections.Specialized;
using Transloadit.Log;

namespace Transloadit
{
    /// <summary>
    /// Sends request to REST API service, then handles the response, which will be represented in an IApiResponse implementation
    /// </summary>
    public class ApiRequest : IApiRequest
    {
        #region Private constants

        /// <summary>
        /// Template for simple form data
        /// </summary>
        private const string FormDataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";

        /// <summary>
        /// Template for form data file
        /// </summary>
        private const string PreFormDataFileTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n\r\n";

        /// <summary>
        /// Template for form data boundary
        /// </summary>
        private const string BoundaryTemplate = "----------{0}";

        /// <summary>
        /// Template for request content type definition
        /// </summary>
        private const string BeginRequestTemplate = "multipart/form-data; boundary={0}";
        
        /// <summary>
        /// Template for the last boundary item, which is used at the end of the manually created request body
        /// </summary>
        private const string EndRequestTemplate = "--{0}--";

        #endregion

        #region Public enums

        /// <summary>
        /// Available request methods
        /// </summary>
        public enum RequestMethod
        {
            /// <summary>
            /// Used for GET requests
            /// </summary>
            [DescriptionAttribute("GET")]
            Get,

            /// <summary>
            /// Used for POST requests
            /// </summary>
            [DescriptionAttribute("POST")]
            Post,

            /// <summary>
            /// Used for PUT requests
            /// </summary>
            [DescriptionAttribute("PUT")]
            Put,

            /// <summary>
            /// Used for DELETE requests
            /// </summary>
            [DescriptionAttribute("DELETE")]
            Delete,

            /// <summary>
            /// Used for PATCH requests
            /// </summary>
            [DescriptionAttribute("PATCH")]
            Patch
        }

        #endregion

        #region Private attributes

        /// <summary>
        /// Request URL
        /// </summary>
        private Uri url;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets and sets data to be posted
        /// </summary>
        public ApiData Data { get; set; }

        /// <summary>
        /// Gets ans sets the host of the current request
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets and sets the method of the current request
        /// </summary>
        public RequestMethod Method { get; set; }

        /// <summary>
        /// Gets and sets the absolute path of the current request
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets and sets the scheme of the current request
        /// </summary>
        public string Scheme { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Set the request method to GET as default
        /// </summary>
        public ApiRequest()
        {
            Method = RequestMethod.Get;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Executes the current requests and gets the result
        /// </summary>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        public IApiResponse Execute()
        {
            BuildUri();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = Method.ToString();

            try
            {
                bool hasBody = (Method == RequestMethod.Put || Method == RequestMethod.Post || Method == RequestMethod.Patch);
                if (hasBody)
                {
                    string boundary = String.Format(BoundaryTemplate, DateTime.Now.Ticks.ToString("x"));
                    request.ContentType = String.Format(BeginRequestTemplate, boundary);

                    List<byte> bytes = new List<byte>();
                    foreach (KeyValuePair<string, object> data in Data.Fields)
                    {
                        bytes.AddRange(Encoding.UTF8.GetBytes(String.Format(FormDataTemplate, boundary, data.Key, data.Value)).ToList<byte>());
                    }

                    foreach (KeyValuePair<string, string> file in Data.Files)
                    {
                        if (File.Exists(file.Value))
                        {
                            bytes.AddRange(Encoding.UTF8.GetBytes(String.Format(PreFormDataFileTemplate, boundary, file.Key, System.IO.Path.GetFileName(file.Value))).ToArray<byte>());
                            bytes.AddRange(File.ReadAllBytes(file.Value).ToList<byte>());
                            bytes.AddRange(Encoding.UTF8.GetBytes(String.Format("\r\n\r\n")).ToArray<byte>());
                        }
                    }

                    bytes.AddRange(Encoding.UTF8.GetBytes(String.Format(EndRequestTemplate, boundary)).ToList<byte>());

                    byte[] postHeaderBytes = bytes.ToArray();
                    request.ContentLength = postHeaderBytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                }
            }
            catch (WebException e)
            {
                LoggerFactory.GetLogger().LogError(this.GetType(), e);
            }

            WebResponse response;

            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                LoggerFactory.GetLogger().LogError(this.GetType(), e);
                response = e.Response;
            }

            try
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream);
                return new ApiResponse(responseStreamReader.ReadToEnd());
            }
            catch (Exception e)
            {
                LoggerFactory.GetLogger().LogError(this.GetType(), e, "Response stream was not able to be handled while sending {0} {1} request.", Method, url);
                return new ApiResponse("{\"status\":\"NO_RESPONSE\", \"message\":\"Response stream was not able to be handled\", \"method\":\"" + Method + "\", \"url\":\"" + url + "\"}");
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Builds up the URL based on the current attributes
        /// </summary>
        private void BuildUri()
        {
            UriBuilder ub = new UriBuilder();
            ub.Scheme = Scheme;
            ub.Host = Host;
            ub.Path = Path;

            url = ub.Uri;
        }

        #endregion
    }
}
