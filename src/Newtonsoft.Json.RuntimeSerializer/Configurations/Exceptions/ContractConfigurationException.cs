using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string propName) : base($"{propName} is not a property")
        {
        }
    }

    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() : base($"property cannot be null or empty")
        {
        }
    }

    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException(string fieldName) : base($"{fieldName} is not a property")
        {
        }
    }

    public class InvalidFieldException : Exception
    {
        public InvalidFieldException() : base($"field cannot be null or empty")
        {
        }
    }
}
