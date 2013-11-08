using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transloadit.Log.Exceptions
{
    /// <summary>
    /// Thrown when logger class is not defined
    /// </summary>
    public class UndefinedLoggerClassException : Exception
    {
        #region Constructor

        public UndefinedLoggerClassException()
            : base("Transloadit logger class is not defined")
        {

        }

        #endregion
    }
}
