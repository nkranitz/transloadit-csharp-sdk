using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Transloadit;

namespace Tests
{
    [TestFixture]
    class FormDataTests
    {
        [Test]
        public void InvokeAssemblyWithFormData()
        {
            ITransloadit transloadit = new Transloadit.Transloadit();
            Transloadit.Assembly.IAssemblyBuilder assembly = new Transloadit.Assembly.AssemblyBuilder();
            assembly.SetField("test", "200");
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(((Dictionary<string, object>)(response.Data["fields"])).Count > 0);
        }

        [Test]
        public void InvokeAssemblyWithoutFormData()
        {
            ITransloadit transloadit = new Transloadit.Transloadit();
            Transloadit.Assembly.IAssemblyBuilder assembly = new Transloadit.Assembly.AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(((Dictionary<string, object>)(response.Data["fields"])).Count == 0);
        }
    }
}
