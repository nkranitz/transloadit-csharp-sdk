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
    class OptionalSettingTests
    {
        [Test]
        public void InvokeAssemblyWithNotifyUrl()
        {
            ITransloadit transloadit = new Transloadit.Transloadit();
            IAssemblyBuilder assembly = new AssemblyBuilder();
            assembly.SetNotifyURL("http://my.localhost");
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }
    }
}
