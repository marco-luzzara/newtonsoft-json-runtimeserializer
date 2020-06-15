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

    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() : base($"property cannot be null or empty")
        {
        }
    }

    public class NotExistingFieldException : Exception
    {
        public NotExistingFieldException(string fieldName) : base($"{fieldName} is not a property")
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
