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
        /// Gets success information about the sent request
        /// </summary>
        bool Success { get; }
    }
}
