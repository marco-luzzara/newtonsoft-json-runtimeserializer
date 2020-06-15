using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions
{
    public class InvalidNameForPropertyException : Exception
    {
        public InvalidNameForPropertyException() : base($"json property name cannot be null or empty")
        {
        }
    }
}
