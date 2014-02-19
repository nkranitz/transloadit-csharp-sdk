using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Transloadit;
using Transloadit.Assembly;

namespace Tests
{
    [TestFixture]
    class FormDataTests
    {
        [Test]
        public void InvokeAssemblyWithFormData()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();
            IStep step = new Transloadit.Assembly.Step();

            step.SetOption("robot", "/image/resize");
            assembly.AddStep("step", step);
            assembly.SetField("test", "200");

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(response.Data["fields"].ToObject<Dictionary<string, object>>().Count > 0);
        }

        [Test]
        public void InvokeAssemblyWithoutFormData()
        {
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();
            IStep step = new Transloadit.Assembly.Step();

            step.SetOption("robot", "/image/resize");
            assembly.AddStep("step", step);

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(response.Data["fields"].ToObject<Dictionary<string, object>>().Count == 0);
        }
    }
}
