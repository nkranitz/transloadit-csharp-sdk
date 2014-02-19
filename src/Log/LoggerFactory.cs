using System;

namespace Transloadit.Log
{
    /// <summary>
    /// Static logger factory for Transloadit. Creates and gets the configured or the default logger for Transloadit
    /// </summary>
    public static class LoggerFactory
    {
        #region Private constants

        /// <summary>
        /// Transloadit logger class for logging. Must be an implementation of ITransloaditLogger 
        /// </summary>
        private const string LoggerClass = "Transloadit.Log.TransloaditLogger, Transloadit";

        #endregion

        #region Private attributes

        /// <summary>
        /// Stores the static instance of an ITransloaditLogger implementation
        /// </summary>
        private static ITransloaditLogger logger;

        /// <summary>
        /// Used for synchronization while accessing the singleton instance
        /// </summary>
        private static object sync = new Object();

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the created logger instance. If the current logger instance is null and an existing logger class is defined 
        /// in the LoggerClass private constant, then a new logger object will be created. Logger class must implement 
        /// ITransloaditLogger interface. If the set class does not implement the required interface, then the default logger will be used.
        /// </summary>
        /// <exception cref="Transloadit.Log.Exception.LoggerClassNotFoundException">
        /// Thrown when the configured class is not exsiting.
        /// </exception>
        /// <returns>Single logger instance, which is an implementation of ITransloaditLogger interface</returns>
        public static ITransloaditLogger GetLogger()
        {
            if (logger == null)
            {
                lock (sync)
                {
                    string type = LoggerFactory.LoggerClass;

                    Type t = Type.GetType(type);
                    if (t == null)
                    {
                        throw new Exceptions.LoggerClassNotFoundException(type);
                    }

                    try
                    {
                        logger = (ITransloaditLogger)Activator.CreateInstance(t);
                    }
                    catch (Exception e)
                    {
                        logger = new TransloaditLogger();
                        LoggerFactory.GetLogger().LogError(Type.GetType("LoggerFactory"), e, "Custom logger instance cannot be created: {0}", t.Name);
                    }
                }
            }
            return logger;
        }

        #endregion
    }
}
