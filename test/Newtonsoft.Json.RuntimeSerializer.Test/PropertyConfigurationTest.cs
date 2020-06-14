using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.RuntimeSerializer.Configurations;
using Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test
{
    [TestClass]
    public class PropertyConfigurationTest
    {
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void Ignore_SetToTrue(bool ignoreValue)
        {
            PropertyConfiguration pc = new PropertyConfiguration();

            pc.Ignore(ignoreValue);

            Assert.AreEqual(ignoreValue, pc.IsIgnored);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidNameForPropertyException))]
        public void HasName_NameNotAccepted(string name)
        {
            PropertyConfiguration pc = new PropertyConfiguration();

            pc.HasName(name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameForPropertyException))]
        public void HasName_NameAccepted()
        {
            string mappedName = "test";
            PropertyConfiguration pc = new PropertyConfiguration();

            pc.HasName(mappedName);

            Assert.AreEqual(mappedName, pc.Name);
        }
    }
}
