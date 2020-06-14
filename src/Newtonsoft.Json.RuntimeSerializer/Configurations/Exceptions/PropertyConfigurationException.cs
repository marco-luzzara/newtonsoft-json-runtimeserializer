using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations.Exceptions
{
    public class InvalidNameForPropertyException : Exception
    {
        public InvalidNameForPropertyException(string name) : base($"{DescribeInvalidName(name)} is an invalid name for a property")
        {
        }

        private static string DescribeInvalidName(string name)
        {
            switch (name)
            {
                case "":
                    return "empty string";
                case null:
                    return "null";
                default:
                    return name;
            }
        }
    }
}
