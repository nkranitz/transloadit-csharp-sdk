using System;
using System.Collections.Generic;
using System.Text;

namespace Transloadit.Assembly
{
    public interface IAssemblyBuilder
    {
        /// <summary>
        /// Adds file to the current assembly
        /// </summary>
        /// <param name="path">Path of the file</param>
        void AddFile(string path);

        /// <summary>
        /// Adds file to the current assembly with specific key
        /// </summary>
        /// <param name="key">Key of the file to be uploaded</param>
        /// <param name="path">Path of the file</param>
        /// <exception cref="Transloadit.Assembly.Exceptions.InvalidFieldKeyException">
        /// Thrown when an invalid (reserved) field key is tried to be used
        /// </exception>
        void AddFile(string key, string path);

        /// <summary>
        /// Adds step to the current assembly
        /// </summary>
        /// <param name="name">Name of the step</param>
        /// <param name="step">Step to be added</param>
        void AddStep(string name, IStep step);

        /// <summary>
        /// Generates and gets the parameter tree of an assembly
        /// </summary>
        /// <returns>Parameters tree</returns>
        Dictionary<string, object> GetParams();

        /// <summary>
        /// Checks whether the assembly has notify URL
        /// </summary>
        bool HasNotifyUrl();

        /// <summary>
        /// Checks whether the assembly has steps
        /// </summary>
        bool HasSteps();

        /// <summary>
        /// Checks whether the assembly has template ID
        /// </summary>
        /// <returns>Existing of set template iD</returns>
        bool HasTemplateID();

        /// <summary>
        /// Sets the expiration datetime of the assembly (as UTC date)
        /// </summary>
        /// <param name="dateTime">Expiration datetime</param>
        void SetAuthExpires(DateTime dateTime);

        /// <summary>
        /// Sets the authentication key for the assembly
        /// </summary>
        /// <param name="key">API key of the user</param>
        void SetAuthKey(string key);

        /// <summary>
        /// Sets the maximum size of the assembly
        /// </summary>
        /// <param name="maxSize">Maximum size (in bytes)</param>
        void SetAuthMaxSize(int maxSize);

        /// <summary>
        /// Sets a custom field in the current assembly
        /// </summary>
        /// <param name="key">Key of the field</param>
        /// <param name="value">Value of the field</param>
        /// <exception cref="Transloadit.Assembly.Exceptions.InvalidFieldKeyException">
        /// Thrown when an invalid (reserved) field key is tried to be used
        /// </exception>
        /// <exception cref="Transloadit.Assembly.Exceptions.AlreadyDefinedKeyException">
        /// Thrown when an already defined key (in files or in fields) is tried to be used
        /// </exception>
        void SetField(string key, object value);

        /// <summary>
        /// Sets the notification URL of the assembly, which will be requested after assembly is completed
        /// </summary>
        /// <param name="notifyURL">Notification URL (e.g.: 'http://my.domain.me/application')</param>
        void SetNotifyURL(string notifyURL);

        /// <summary>
        /// Sets the used template ID of the assmebly (you can create multiple Transloadit templates under your account,please use its unique ID here)
        /// </summary>
        /// <param name="templateID">Template ID of the assmebly</param>
        void SetTemplateID(string templateID);

        /// <summary>
        /// Converts the builder to ApiData and gets the object, which will be the base of the sent Transloadit request
        /// </summary>
        /// <returns>Data to be sent to Transloadit backend</returns>
        ApiData ToApiData();

        /// <summary>
        /// Converts the builder to JSON string and gets it
        /// </summary>
        /// <returns>Parameter tree as JSON string</returns>
        string ToJsonString();
    }
}
