using Newtonsoft.Json.RuntimeSerializer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer
{
    public class ContractConfiguration<T>
    {
        protected Dictionary<string, PropertyConfiguration> globalPropertyMapping = new Dictionary<string, PropertyConfiguration>();

        public ContractConfiguration()
        {
        }

        public IDictionary<string, PropertyConfiguration> GetGlobalPropertyMapping => globalPropertyMapping.ToDictionary(x => x.Key, x => x.Value);

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
