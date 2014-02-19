namespace Transloadit
{
    /// <summary>
    /// General interface for accessing REST API service
    /// </summary>
    public interface IApiRequest
    {
        /// <summary>
        /// Gets and sets data to be posted
        /// </summary>
        ApiData Data { get; set; }

        /// <summary>
        /// Gets ans sets the host of the current request
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets and sets the method of the current request
        /// </summary>
        ApiRequestMethods.RequestMethod Method { get; set; }

        /// <summary>
        /// Gets and sets the absolute path of the current request
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Gets and sets the scheme of the current request
        /// </summary>
        string Scheme { get; set; }

        /// <summary>
        /// Executes the current requests and gets the result
        /// </summary>
        /// <returns>Represents the whole result of the request. Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        IApiResponse Execute();
    }
}
