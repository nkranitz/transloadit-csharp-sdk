using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Transloadit;
using Transloadit.Assembly;

namespace Tests
{
    [TestFixture]
    class AuthenticationTests
    {
        [Test]
        public void AuthenticateWithExistingAccount()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new Transloadit.Assembly.AssemblyBuilder();
            IStep step = new Transloadit.Assembly.Step();

            step.SetOption("robot", "/image/resize");
            assembly.AddStep("step", step);
            assembly.SetField("test", "200");

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }

        [Test]
        public void AuthenticateWithNonExistingAccount()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("GET_ACCOUNT_UNKNOWN_AUTH_KEY", (string)response.Data["error"]);
        }

        [Test]
        public void WrongSecretKey()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("INVALID_SIGNATURE", (string)response.Data["error"]);
        }
    }
}
