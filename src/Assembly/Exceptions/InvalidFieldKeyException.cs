using System;

namespace Transloadit.Assembly.Exceptions
{
    /// <summary>
    /// Thrown when the specified field name is invalid
    /// </summary>
    public class InvalidFieldKeyException : Exception
    {
        #region Constructors

        public InvalidFieldKeyException(string key)
            : base(String.Format("Invalid key was tried to be set: {0}: ", key))
        {

        }

        #endregion
    }
}
