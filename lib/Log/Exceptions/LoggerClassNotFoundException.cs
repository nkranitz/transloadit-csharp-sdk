using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
