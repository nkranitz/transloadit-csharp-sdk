using System.ComponentModel;

namespace Transloadit
{
    public class ApiRequestMethods
    {
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
    }
}
