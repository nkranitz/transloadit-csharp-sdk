using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit.Exceptions
{
    /// <summary>
    /// Thrown when an ApiRequest is tried to be sent without host
    /// </summary>
    public class MissingHostException : Exception
    {
        #region Constructors

        public MissingHostException()
            : base("Host is missing")
        {

        }

        #endregion
    }
}
