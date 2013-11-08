using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Transloadit;

namespace Tests
{
    [TestFixture]
    class UseTemplateTests
    {
        [Test]
        public void ExistingTemplate()
        {
            ITransloadit transloadit = new Transloadit.Transloadit();
            Transloadit.Assembly.IAssemblyBuilder assembly = new Transloadit.Assembly.AssemblyBuilder();
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }

        [Test]
        public void NonExistingTemplate()
        {
            ITransloadit transloadit = new Transloadit.Transloadit();
            Transloadit.Assembly.IAssemblyBuilder assembly = new Transloadit.Assembly.AssemblyBuilder();
            assembly.SetTemplateID(transloadit.Config.DefaultTemplateID + "hack");
            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("TEMPLATE_NOT_FOUND", response.Data["error"]);
        }
    }
}
