using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.RuntimeSerializer.Test.Model;
using System.Collections.Generic;

namespace Newtonsoft.Json.RuntimeSerializer.Test
{
    [TestClass]
    public class RuntimeContractResolverTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestB tb = new TestB() { IdB = 2 };
            TestA ta = new TestA() { IdA = 1, TestBReference = tb };
            tb.TestAReferences = new List<TestA>() {
                new TestA() { IdA = 3 },
                new TestA() { IdA = 6 }
            };
            //tb.TestAReference.TestBReference = new TestB() { Id = 4 };
            //ta.TestBReference.TestAReference.TestBReference = null;

            var serializerSettings = new JsonSerializerSettings() 
            {
                ContractResolver = new RuntimeContractResolver(),
                TraceWriter = new ReportingTraceWriter()
            };

            var json = JsonConvert.SerializeObject(ta, serializerSettings);
        }
    }
}
