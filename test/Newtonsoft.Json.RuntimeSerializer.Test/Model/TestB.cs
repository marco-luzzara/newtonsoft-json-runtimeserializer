using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Model
{
    [DataContract]
    public class TestB
    {
        [DataMember(Name = "id")]
        public int IdB { get; set; }

        [DataMember(Name = "testA")]
        public List<TestA> TestAReferences { get; set; }
    }
}
