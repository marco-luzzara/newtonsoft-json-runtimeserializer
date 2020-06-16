using Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations
{
    public class PropertyConfiguration
    {
        protected string name = null;
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        protected bool? isIgnored = null;
        public bool? IsIgnored 
        {
            get
            {
                return this.isIgnored;
            }
        }

        public PropertyConfiguration Ignore(bool isIgnored = true)
        {
            this.isIgnored = isIgnored;
            return this;
        }

        public PropertyConfiguration HasName(string propName)
        {
            if (string.IsNullOrEmpty(propName))
                throw new InvalidNameForPropertyException();

            this.name = propName;
            return this;
        }
    }
}
