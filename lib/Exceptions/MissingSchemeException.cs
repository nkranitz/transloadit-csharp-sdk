using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit.Exceptions
{
    /// <summary>
    /// Thrown when an ApiRequest is tried to be sent without scheme
    /// </summary>
    public class MissingSchemeException : Exception
    {
        #region Constructors

        public MissingSchemeException()
            : base("Request protocol is not defined")
        {

        }

        #endregion
    }
}
