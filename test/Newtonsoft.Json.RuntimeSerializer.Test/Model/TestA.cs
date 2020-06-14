using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Model
{
    [DataContract]
    public class TestA
    {
        [DataMember(Name = "id")]
        public int IdA { get; set; }

        private int PrivateProp { get; set; }

        private int privateField;

        [DataMember(Name = "testB")]
        public TestB TestBReference { get; set; }

        public int TestMe() => 1;
    }
}
