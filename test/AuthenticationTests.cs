using System;
using System.Collections.Generic;
using System.Linq;
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
            ITransloadit transloadit = new Transloadit.Transloadit();
            IAssemblyBuilder assembly = new AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }

        [Test]
        public void AuthenticateWithNonExistingAccount()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("non-existing-account");
            IAssemblyBuilder assembly = new AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("GET_ACCOUNT_UNKNOWN_AUTH_KEY", response.Data["error"]);
        }

        [Test]
        public void WrongSecretKey()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("wrong-secret-key");
            IAssemblyBuilder assembly = new AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("INVALID_SIGNATURE", response.Data["error"]);
        }
    }
}
