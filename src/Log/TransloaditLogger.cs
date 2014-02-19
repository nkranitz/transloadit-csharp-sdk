using System;

namespace Transloadit.Log
{
    /// <summary>
    /// Default Transloadit logger implementation
    /// </summary>
    class TransloaditLogger : ITransloaditLogger
    {
        #region Private constants

        /// <summary>
        /// Enables logging
        /// </summary>
        private const bool Enabled = true;

        #endregion

        #region Public methods

        /// <summary>
        /// Logs information during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="message">Parameterized info message</param>
        /// <param name="parameters">Parameters for the passed info message</param>
        public void LogInfo(Type type, string message, params object[] parameters)
        {
            if (TransloaditLogger.Enabled)
            {
                Console.Write("Info: ");
                Console.Write(type.Name);
                Console.Write(" | ");
                Console.WriteLine(String.Format(message, parameters));
                Console.WriteLine("-------------");
            }
        }

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="exception">Exception, which is the reason of the error</param>
        /// <param name="message">Parameterized error message</param>
        /// <param name="parameters">Parameters for the passed error message</param>
        public void LogError(Type type, Exception exception, string message, params object[] parameters)
        {
            if (TransloaditLogger.Enabled)
            {
                Console.Write("Error: ");
                Console.WriteLine(type.Name);
                Console.Write(" | ");
                Console.WriteLine(String.Format(message, parameters));
                Console.Write("Exception message: ");
                Console.WriteLine(exception.Message);
                Console.WriteLine("-------------");
            }
        }

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="message">Parameterized error message</param>
        /// <param name="parameters">Parameters for the passed error message</param>
        public void LogError(Type type, string message, params object[] parameters)
        {
            if (TransloaditLogger.Enabled)
            {
                Console.Write("Error: ");
                Console.WriteLine(type.Name);
                Console.Write(" | ");
                Console.WriteLine(String.Format(message, parameters));
                Console.WriteLine("-------------");
            }
        }

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="exception">Exception, which is the reason of the error</param>
        public void LogError(Type type, Exception exception)
        {
            if (TransloaditLogger.Enabled)
            {
                Console.Write("Error: ");
                Console.WriteLine(type.Name);
                Console.Write(" | ");
                Console.Write("Exception message: ");
                Console.WriteLine(exception.Message);
                Console.WriteLine("-------------");
            }
        }

        #endregion
    }
}
