using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Model
{
    [DataContract]
    public class TestB
    {
        [DataMember(Name = "idB")]
        public int IdB { get; set; } = 0;

        [DataMember(Name = "testAs")]
        public List<TestA> TestAReferences { get; set; } = new List<TestA>();
    }
}
