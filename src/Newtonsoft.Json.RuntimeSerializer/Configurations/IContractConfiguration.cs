﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer.Configurations
{
    public interface IContractConfiguration
    {
        Type ModelType { get; }

        IDictionary<MemberInfo, PropertyConfiguration> PropertiesMapping { get; }
    }
}
