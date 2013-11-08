using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using Transloadit.Config;

namespace Transloadit.Log
{
    /// <summary>
    /// Static logger factory for Transloadit. Creates and gets the configured or the default logger for Transloadit
    /// </summary>
    public static class LoggerFactory
    {
        #region Private attributes

        /// <summary>
        /// Stores the static instance of an ITransloaditLogger implementation
        /// </summary>
        private static ITransloaditLogger logger;

        #endregion

        #region Static initializator

        /// <summary>
        /// Initializates the logger factory. If an existing logger class is defined in the app config, 
        /// then a new logger object will be created. Logger class must implement ITransloaditLogger interface. 
        /// If log element does not exist, or the set class does not implement the required interface,
        /// then the default logger wll be used.
        /// </summary>
        /// <exception cref="Transloadit.Log.Exception.UndefinedLoggerClassException">
        /// Thrown when Transloadit log element is defined in the app config, but class attribute is not set.
        /// </exception>
        /// <exception cref="Transloadit.Log.Exception.LoggerClassNotFoundException">
        /// Thrown when the configured class is not exsiting.
        /// </exception>
        static LoggerFactory()
        {
            TransloaditConfigSection section = (TransloaditConfigSection)ConfigurationManager.GetSection("transloadit");

            if (section.TransloaditLogConfig.ElementInformation.IsPresent)
            {
                if (section.TransloaditLogConfig.Type == null)
                {
                    throw new Exceptions.UndefinedLoggerClassException();
                }

                Type t = Type.GetType(section.TransloaditLogConfig.Type);
                if (t == null)
                {
                    throw new Exceptions.LoggerClassNotFoundException(section.TransloaditLogConfig.Type);
                }

                try
                {    
                    logger = (ITransloaditLogger)Activator.CreateInstance(t);
                }
                catch (Exception e)
                {
                    LoggerFactory.GetLogger().LogError(Type.GetType("LoggerFactory"), e, "Custom logger instance cannot be created: {0}", t.Name);
                    logger = new TransloaditLogger();
                }
            }
            else
            {
                logger = new TransloaditLogger();
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the created logger instance
        /// </summary>
        /// <returns>Single logger instance, which is an implementation of ITransloaditLogger interface</returns>
        public static ITransloaditLogger GetLogger()
        {
            return logger;
        }

        #endregion
    }
}
