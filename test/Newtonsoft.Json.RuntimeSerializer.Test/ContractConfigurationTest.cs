using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions;
using Newtonsoft.Json.RuntimeSerializer.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test
{
    [TestClass]
    public class ContractConfigurationTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyFromExpr_AccessMethod_Throw()
        {
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.TestMethod());
        }

        [TestMethod]
        public void PropertyFromExpr_AccessProperty()
        {
            var mappedName = "testok";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IdA).HasName(mappedName);

            var mapping = cc.PropertiesMapping.First();

            Assert.AreEqual("IdA", mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        public void PropertyFromExpr_ConfigureTwice_OverwriteConfig()
        {
            var mappedName = "testok";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(ta => ta.IdA).HasName("before");
            cc.Property(ta => ta.IdA).HasName(mappedName);

            var mapping = cc.PropertiesMapping.Single();

            Assert.AreEqual("IdA", mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(PropertyNotFoundException))]
        public void PropertyFromString_AccessMethod_Throw()
        {
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property("TestMe");
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidPropertyException))]
        public void PropertyFromString_InvalidProperty_Throw(string propName)
        {
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(propName);
        }

        [DataTestMethod]
        [DataRow("PrivateProp")]
        [DataRow("IdA")]
        public void PropertyFromString_AccessProperty(string propName)
        {
            var mappedName = "testok";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(propName).HasName(mappedName);

            var mapping = cc.PropertiesMapping.First();

            Assert.AreEqual(propName, mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [DataTestMethod]
        [DataRow("PrivateProp")]
        [DataRow("IdA")]
        public void PropertyFromString_ConfigureTwice_OverwriteConfig(string propName)
        {
            var mappedName = "testok";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Property(propName).HasName("before");
            cc.Property(propName).HasName(mappedName);

            var mapping = cc.PropertiesMapping.Single();

            Assert.AreEqual(propName, mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(FieldNotFoundException))]
        public void FieldFromString_AccessMethod_Throw()
        {
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field("TestMe");
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidFieldException))]
        public void FieldFromString_ArgNull_Throw(string fieldName)
        {
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field(fieldName);
        }

        [TestMethod]
        public void FieldFromString_AccessPrivateField()
        {
            var mappedName = "testok";
            var fieldName = "privateField";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field(fieldName).HasName(mappedName);

            var mapping = cc.PropertiesMapping.First();

            Assert.AreEqual(fieldName, mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        public void FieldFromString_ConfigureTwice_OverwriteConfig()
        {
            var mappedName = "testok";
            var fieldName = "privateField";
            ContractConfiguration<TestA> cc = new ContractConfiguration<TestA>();
            cc.Field(fieldName).HasName("before");
            cc.Field(fieldName).HasName(mappedName);

            var mapping = cc.PropertiesMapping.Single();

            Assert.AreEqual(fieldName, mapping.Key.Name);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }
    }
}
