namespace Transloadit
{
    /// <summary>
    /// Interface for transloadit JSON response handler
    /// </summary>
    interface ITransloaditJsonResponse
    {
        /// <summary>
        /// Tries to parse the sent JSON string into Data tree
        /// </summary>
        bool ParseJsonResponseString();
    }
}
