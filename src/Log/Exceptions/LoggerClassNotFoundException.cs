using System;

namespace Transloadit.Log.Exceptions
{
    /// <summary>
    /// Thrown when the logger class is not found
    /// </summary>
    class LoggerClassNotFoundException : Exception
    {
        #region Constructors

        public LoggerClassNotFoundException(string className)
            : base("Logger class is not existing: " + className)
        {

        }

        #endregion
    }
}
