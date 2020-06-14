using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions
{
    public class NotExistingPropertyException : Exception
    {
        public NotExistingPropertyException(string propName) : base($"{propName} is not a property")
        {
        }
    }

    public class NotExistingFieldException : Exception
    {
        public NotExistingFieldException(string fieldName) : base($"{fieldName} is not a property")
        {
        }
    }
}
