using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Model
{
    [JsonObject]
    public class TestB
    {
        [JsonProperty(PropertyName = "idB")]
        public int IdB { get; set; } = 0;

        [JsonProperty(PropertyName = "testAs")]
        public List<TestA> TestAReferences { get; set; } = new List<TestA>();
    }
}
