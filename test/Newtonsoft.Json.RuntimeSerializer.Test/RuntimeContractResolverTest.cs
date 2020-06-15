using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.RuntimeSerializer.Configurations;
using Newtonsoft.Json.RuntimeSerializer.Test.Model;
using Newtonsoft.Json.RuntimeSerializer.Test.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.RuntimeSerializer.Test
{
    [TestClass]
    public class RuntimeContractResolverTest
    {
        protected JsonSerializerSettings GetSettings(params IContractConfiguration[] contractConfigurations)
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = new RuntimeContractResolver(contractConfigurations),
            };
        }

        [TestMethod]
        [Ignore]
        public void TestMethod()
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

        #region Public property
        [TestMethod]
        public void Serialize_UnnamedProperty()
        {
            TestA ta = new TestA() { UnnamedProperty = 1 };
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.UnnamedProperty).HasName("unnamed_property");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unnamed_property", 1));
        }

        [TestMethod]
        public void Serialize_OverridePropertyName()
        {
            TestA ta = new TestA() { IdA = 1 };
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IdA).HasName("id_a");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("id_a", 1));
        }

        [TestMethod]
        public void Serialize_IgnoreProperty()
        {
            TestA ta = new TestA() { IdA = 1 };
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IdA).Ignore();

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsFalse(jsAssert.HasProperty("id"));
        }

        [TestMethod]
        public void Serialize_UnIgnoreProperty()
        {
            TestA ta = new TestA() { IgnoredProperty = 1 };
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IgnoredProperty).Ignore(false).HasName("unignored_property");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unignored_property", 1));
        }
        #endregion

        #region Private property
        [TestMethod]
        public void Serialize_UnnamedPrivateProperty()
        {
            TestA ta = new TestA();
            ta.SetUnnamedPrivateProp(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property("UnnamedPrivateProperty").HasName("unnamed_private_property");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unnamed_private_property", 1));
        }

        [TestMethod]
        public void Serialize_OverridePrivatePropertyName()
        {
            TestA ta = new TestA();
            ta.SetPrivateProp(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property("PrivateProp").HasName("private_prop");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("private_prop", 1));
        }

        [TestMethod]
        public void Serialize_IgnorePrivateProperty()
        {
            TestA ta = new TestA();
            ta.SetPrivateProp(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property("PrivateProp").Ignore();

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsFalse(jsAssert.HasProperty("privateProperty"));
        }

        [TestMethod]
        public void Serialize_UnIgnorePrivateProperty()
        {
            TestA ta = new TestA();
            ta.SetIgnoredPrivateProp(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property("IgnoredPrivateProperty").Ignore(false).HasName("unignored_private_property");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unignored_private_property", 1));
        }
        #endregion

        #region Private field
        [TestMethod]
        public void Serialize_UnnamedPrivateField()
        {
            TestA ta = new TestA();
            ta.SetUnnamedPrivateField(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field("unnamedPrivateField").HasName("unnamed_private_field");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unnamed_private_field", 1));
        }

        [TestMethod]
        public void Serialize_OverridePrivateFieldName()
        {
            TestA ta = new TestA();
            ta.SetPrivateField(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field("privateField").HasName("private_field");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("private_field", 1));
        }

        [TestMethod]
        public void Serialize_IgnorePrivateField()
        {
            TestA ta = new TestA();
            ta.SetPrivateField(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field("privateField").Ignore();

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsFalse(jsAssert.HasProperty("privateField"));
        }

        [TestMethod]
        public void Serialize_UnIgnorePrivateField()
        {
            TestA ta = new TestA();
            ta.SetIgnoredPrivateField(1);
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field("ignoredPrivateField").Ignore(false).HasName("unignored_private_field");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("unignored_private_field", 1));
        }
        #endregion

        #region Nested object
        [TestMethod]
        public void Serialize_NestedObjectNaming()
        {
            TestA ta = new TestA();
            ta.TestBReference = new TestB() { IdB = 1 };
            ContractConfiguration<TestB> cc = new ContractConfiguration<TestB>();
            cc.Property(tb => tb.IdB).HasName("id_b");

            var json = JsonConvert.SerializeObject(ta, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json, jt => jt["testB"]);
            Assert.IsTrue(jsAssert.HasPropertyWithValue("id_b", 1));
        }

        [TestMethod]
        public void Serialize_NestedArrayNaming()
        {
            TestB tb = new TestB() { IdB = 1 };
            tb.TestAReferences.Add(new TestA() { IdA = 1 });
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IdA).HasName("id_a");

            var json = JsonConvert.SerializeObject(tb, GetSettings(cc));

            JsonStringValidator jsAssert = new JsonStringValidator(json, jt => jt["testAs"].Cast<JArray>().Single());
            Assert.IsTrue(jsAssert.HasPropertyWithValue("id_a", 1));
        }
        #endregion
    }
}
