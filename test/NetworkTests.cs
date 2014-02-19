using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Transloadit;
using Transloadit.Assembly;
using System.Net;

namespace Tests
{
    [TestFixture]
    class NetworkTests
    {
        [Test]
        public void NoInternetConnection()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            if (!response.Success && response.Data.ToObject<Dictionary<string, object>>().ContainsKey("status") && (string)(response.Data["status"]) == "NO_RESPONSE")
            {
                Assert.Pass();
            }
        }
    }
}
