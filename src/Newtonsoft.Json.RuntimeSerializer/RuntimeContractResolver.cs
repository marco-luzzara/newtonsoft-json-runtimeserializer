using Newtonsoft.Json.RuntimeSerializer.Configurations;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.RuntimeSerializer
{
    public class RuntimeContractResolver : DefaultContractResolver
    {
        protected Dictionary<Type, IContractConfiguration> contractConfigurationsDict;

        public RuntimeContractResolver(params IContractConfiguration[] contractConfigurations)
        {
            this.contractConfigurationsDict = contractConfigurations.ToDictionary(x => x.ModelType, x => x);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (!this.contractConfigurationsDict.TryGetValue(prop.DeclaringType, out var contractConfig))
                return prop;

            if (!contractConfig.PropertiesMapping.TryGetValue(member.Name, out var propConfig))
                return prop;

            return ConfigureJsonproperty(prop, propConfig);
        }

        protected JsonProperty ConfigureJsonproperty(JsonProperty prop, PropertyConfiguration propConfig)
        {
            if (propConfig.IsIgnored.HasValue)
            {
                var isIgnored = propConfig.IsIgnored.Value;
                prop.Ignored = isIgnored;
            }

            if (propConfig.Name != null)
                prop.PropertyName = propConfig.Name;

            return prop;
        }
    }
}
