using System;
using System.Collections.Generic;
using System.Text;

using Transloadit.Assembly;
using Transloadit.Config;

namespace Transloadit
{
    /// <summary>
    /// Interface for accessing Transloadit services
    /// </summary>
    public interface ITransloadit
    {
        /// <summary>
        /// Gets the created config instance
        /// </summary>
        TransloaditConfigElement Config { get; }

        /// <summary>
        /// Gets and sets API Key of the current Transloadit user. This key is used for each Transloadit request
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Gets and sets API Secret code of the current Transloadit user. This code is used for each request if signature authentication is enabled 
        /// </summary>
        string Secret { get; set; }

        /// <summary>
        /// Tries to delete an assembly by the specified assembly ID.
        /// </summary>
        /// <param name="assemblyID">ID of the assembly which will be tried to be deleted</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        /// <exception cref="Transloadit.Config.Exceptions.ConfigNotSetException">
        /// Thrown when the config is not set before invoke an assembly
        /// </exception>
        TransloaditResponse DeleteAssembly(string assemblyID);

        /// <summary>
        /// Tries to create the specified assembly on Transloadit. Bored instance is requested at first. If there is one, then it will
        /// be used to proceed the request, which can be completed on a bored instance.
        /// </summary>
        /// <param name="assembly">Specified assembly which will be tried to be created.
        /// Please use TransloaditAssemblyBuilder to create a new assembly</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        /// <exception cref="Transloadit.Config.Exceptions.ConfigNotSetException">
        /// Thrown when the config is not set before invoke an assembly
        /// </exception>
        TransloaditResponse InvokeAssembly(IAssemblyBuilder assembly);

        /// <summary>
        /// Creates and gets a new TransloaditRequest instance with default attributes
        /// </summary>
        /// <returns>TransloaditRequest instance with default attributes</returns>
        TransloaditRequest Request();

        /// <summary>
        /// Creates then tries to proceed the specified or a default request, then executes this and gets the response of it.
        /// </summary>
        /// <param name="request">Optional request which will be tried to be executed</param>
        /// <returns>Represents the whole result of the request. 
        /// Response object will be created everytime, please use its properties to get the detailed result on the request</returns>
        TransloaditResponse RequestAndExecute(TransloaditRequest request = null);
    }
}
