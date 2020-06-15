using Newtonsoft.Json.RuntimeSerializer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer
{
    public class ContractConfiguration<T> : IContractConfiguration
    {
        protected Dictionary<string, PropertyConfiguration> propertiesMapping = new Dictionary<string, PropertyConfiguration>();

        public Type ModelType => typeof(T);

        public IDictionary<string, PropertyConfiguration> PropertiesMapping => propertiesMapping.ToDictionary(x => x.Key, x => x.Value);

        public PropertyConfiguration Property(Expression<Func<T, object>> propExpr)
        {
            throw new Exception();
        }

        public PropertyConfiguration Property(string propName)
        {
            throw new Exception();
        }

        public PropertyConfiguration Field(string fieldName)
        {
            throw new Exception();
        }
    }
}
