using System;
using System.Collections.Generic;
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
            ITransloadit transloadit = new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
            IAssemblyBuilder assembly = new AssemblyBuilder();
            IStep step = new Transloadit.Assembly.Step();

            assembly.SetNotifyURL("http://my.localhost");
            step.SetOption("robot", "/image/resize");
            assembly.AddStep("step", step);

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }
    }
}
