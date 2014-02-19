using System.Text;
using System.Security.Cryptography;

namespace Transloadit
{
    /// <summary>
    /// Util functions for Transoadit
    /// </summary>
    public static class Utils
    {
        #region Public methods

        /// <summary>
        /// Generates and gets SHA1 string based on the passed parameters
        /// </summary>
        /// <param name="key">Key of the hash</param>
        /// <param name="str">String to be secured</param>
        /// <returns>SHA1 hash</returns>
        public static string GetSha1(string key, string str)
        {
            var keyByte = Encoding.UTF8.GetBytes(key);
            var hmacsha1 = new HMACSHA1(keyByte);
            var messageBytes = Encoding.Default.GetBytes(str);
            hmacsha1.ComputeHash(messageBytes);

            byte[] buff = hmacsha1.Hash;
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("x2");
            }
            return sbinary;
        }

        #endregion
    }
}
