﻿using Newtonsoft.Json.RuntimeSerializer.Configurations;
using Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions;
using Newtonsoft.Json.RuntimeSerializer.Utils;
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

        public PropertyConfiguration Property<U>(Expression<Func<T, U>> propExpr)
        {
            var propInfo = PropertyProvider.GetPropertyInfoFromExpr(propExpr);

            return AddOrGetPropertyConfiguration(propInfo.Name);
        }

        public PropertyConfiguration Property(string propName)
        {
            if (string.IsNullOrEmpty(propName))
                throw new InvalidPropertyException();

            var propInfo = PropertyProvider.GetPropertyInfoFromName<T>(propName);

            if (propInfo is null)
                throw new PropertyNotFoundException(propName);

            return AddOrGetPropertyConfiguration(propInfo.Name);
        }

        public PropertyConfiguration Field(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new InvalidFieldException();

            var fieldInfo = PropertyProvider.GetFieldInfoFromName<T>(fieldName);

            if (fieldInfo is null)
                throw new FieldNotFoundException(fieldName);

            return AddOrGetPropertyConfiguration(fieldInfo.Name);
        }

        protected PropertyConfiguration AddOrGetPropertyConfiguration(string propName)
        {
            PropertyConfiguration pc;
            if (this.propertiesMapping.TryGetValue(propName, out pc))
                return pc;

            pc = new PropertyConfiguration();
            this.propertiesMapping.Add(propName, pc);

            return pc;
        }
    }
}
