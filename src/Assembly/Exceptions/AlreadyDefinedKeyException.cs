using System;

namespace Transloadit.Assembly.Exceptions
{
    /// <summary>
    /// Thrown when a key is already defined
    /// </summary>
    public class AlreadyDefinedKeyException : Exception
    {
        #region Constructors

        public AlreadyDefinedKeyException(string key, string location)
            : base(String.Format("Key is already defined: {0}, in {1}", key, location))
        {

        }

        #endregion
    }
}
