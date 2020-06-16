using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Test.Utils
{
    public class JsonStringValidator
    {
        protected JToken jToken;
        public JsonStringValidator(string json, Func<JToken, JToken> nestedAccess = null)
        {
            this.jToken = JToken.Parse(json);
            if (nestedAccess != null)
                this.jToken = nestedAccess(this.jToken);
        }
        public bool HasProperty(string propName)
        {
            return jToken[propName] != null;
        }

        public bool HasPropertyWithValue<T>(string propName, T propValue)
            where T : IComparable
        {
            return HasProperty(propName) && 
                jToken[propName].Value<T>().CompareTo(propValue) == 0;
        }
    }
}
