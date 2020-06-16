using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Model
{
    [JsonObject]
    public class TestA
    {
        [JsonProperty(PropertyName = "idA")]
        public int IdA { get; set; } = 0;

        [JsonProperty(PropertyName = "privateProperty")]
        private int PrivateProp { get; set; } = 0;

        [JsonProperty(PropertyName = "privateField")]
        private int privateField = 0;



        [JsonIgnore]
        public int IgnoredProperty { get; set; } = 0;

        [JsonIgnore]
        [JsonProperty]
        private int IgnoredPrivateProperty { get; set; } = 0;

        [JsonIgnore]
        [JsonProperty]
        private int ignoredPrivateField = 0;



        public int UnnamedProperty { get; set; } = 0;

        [JsonProperty]
        private int UnnamedPrivateProp { get; set; } = 0;

        [JsonProperty]
        private int unnamedPrivateField = 0;



        [JsonProperty(PropertyName = "testB")]
        public TestB TestBReference { get; set; }



        public int TestMethod() => 1;

        public void SetPrivateProp(int num)
        {
            this.PrivateProp = num;
        }

        public void SetPrivateField(int num)
        {
            this.privateField = num;
        }

        public void SetUnnamedPrivateProp(int num)
        {
            this.UnnamedPrivateProp = num;
        }

        public void SetUnnamedPrivateField(int num)
        {
            this.unnamedPrivateField = num;
        }

        public void SetIgnoredPrivateProp(int num)
        {
            this.IgnoredPrivateProperty = num;
        }

        public void SetIgnoredPrivateField(int num)
        {
            this.ignoredPrivateField = num;
        }
    }
}
