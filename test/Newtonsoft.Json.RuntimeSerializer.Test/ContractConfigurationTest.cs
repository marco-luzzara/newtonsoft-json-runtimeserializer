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
        [ExpectedException(typeof(NotExistingPropertyException))]
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

            Assert.AreEqual("IdA", mapping.Key);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NotExistingPropertyException))]
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

            Assert.AreEqual(propName, mapping.Key);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NotExistingFieldException))]
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

            Assert.AreEqual(fieldName, mapping.Key);
            Assert.AreEqual(mappedName, mapping.Value.Name);
        }
    }
}
