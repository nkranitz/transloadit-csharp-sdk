using System;

namespace Transloadit.Log
{
    /// <summary>
    /// Interface for Transloadit log. Custom loggers can be created, which are implements that interface
    /// </summary>
    public interface ITransloaditLogger
    {
        /// <summary>
        /// Logs information during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="message">Parameterized info message</param>
        /// <param name="parameters">Parameters for the passed info message</param>
        void LogInfo(Type type, string message, params object[] parameters);

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="exception">Exception, which is the reason of the error</param>
        /// <param name="message">Parameterized error message</param>
        /// <param name="parameters">Parameters for the passed error message</param>
        void LogError(Type type, Exception exception, string message, params object[] parameters);

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="message">Parameterized error message</param>
        /// <param name="parameters">Parameters for the passed error message</param>
        void LogError(Type type, string message, params object[] parameters);

        /// <summary>
        /// Logs errors during application processes 
        /// </summary>
        /// <param name="type">Type of the class, where the log is proceed</param>
        /// <param name="exception">Exception, which is the reason of the error</param>
        void LogError(Type type, Exception exception);
    }
}
