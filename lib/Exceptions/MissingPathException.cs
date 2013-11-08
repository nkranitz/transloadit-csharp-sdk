using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit.Exceptions
{
    /// <summary>
    /// Thrown when an ApiRequest is tried to be sent without path
    /// </summary>
    public class MissingPathException : Exception
    {
        #region PathException

        public MissingPathException()
            : base("Path is not defined")
        {

        }

        #endregion
    }
}
