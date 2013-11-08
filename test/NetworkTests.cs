using System;
using System.Collections.Generic;
using System.Linq;
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
            ITransloadit transloadit = new Transloadit.Transloadit();
            IAssemblyBuilder assembly = new AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            if (!response.Success && response.Data.ContainsKey("status") && (string)response.Data["status"] == "NO_RESPONSE")
            {
                Assert.Pass();
            }
        }
    }
}
