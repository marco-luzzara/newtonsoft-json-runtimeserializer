using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.RuntimeSerializer
{
    public class RuntimeContractResolver : DefaultContractResolver
    {
        protected int callstack = 0;

        protected void WriteLine(string message)
        {
            Console.WriteLine($"{new string(' ', callstack * 2)}{message}");
        }

        protected T WrapForCS<T>(Func<T> Callback)
        {
            callstack++;
            var retValue = Callback();
            callstack--;

            return retValue;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            return WrapForCS(() =>
            {
                WriteLine($"before CreateProperty with member {member.Name} for decl type {member.DeclaringType.FullName}");
                var prop = base.CreateProperty(member, memberSerialization);
                WriteLine($"after CreateProperty with property {prop.PropertyName} for decl type {member.DeclaringType.FullName}");



                return prop;
            });
        }

        internal void TestOnSerializingCallback(object value, StreamingContext context) 
        {
            Console.WriteLine($"started serializing {value}");
        }

        internal void TestOnSerializedCallback(object value, StreamingContext context)
        {
            Console.WriteLine($"finished serializing {value}");
        }

        protected override JsonContract CreateContract(Type objectType)
        {
            return WrapForCS(() =>
            {
                WriteLine($"before CreateContract for type {objectType.FullName}");
                var contract = base.CreateContract(objectType);
                contract.OnSerializingCallbacks.Add(new SerializationCallback(TestOnSerializingCallback));
                contract.OnSerializedCallbacks.Add(new SerializationCallback(TestOnSerializedCallback));
                WriteLine($"after CreateContract for type {objectType.FullName}");

                return contract;
            });
        }

        //protected override JsonObjectContract CreateObjectContract(Type objectType)
        //{
        //    return WrapForCS(() =>
        //    {
        //        WriteLine($"before CreateObjectContract for type {objectType.FullName}");
        //        var contract = base.CreateObjectContract(objectType);
        //        WriteLine($"after CreateObjectContract for type {objectType.FullName}");

        //        return contract;
        //    });
        //}

        //protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        //{
        //    return WrapForCS(() =>
        //    {
        //        WriteLine($"before CreateProperties for type {type.FullName}");
        //        var props = base.CreateProperties(type, memberSerialization);
        //        WriteLine($"after CreateProperties {string.Join(", ", props)} for type {type.FullName}");

        //        return props;
        //    });
        //}

        //protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        //{
        //    return WrapForCS(() =>
        //    {
        //        WriteLine($"before GetSerializableMembers for type {objectType.FullName}");
        //        var members = base.GetSerializableMembers(objectType);
        //        WriteLine($"after GetSerializableMembers {string.Join(", ", members.Select(m => m.Name))} for type {objectType.FullName}");

        //        return members;
        //    });
        //}

        public override JsonContract ResolveContract(Type type)
        {
            return WrapForCS(() =>
            {
                WriteLine($"before ResolveContract for type {type.FullName}");
                var contract = base.ResolveContract(type);
                WriteLine($"after ResolveContract for type {type.FullName}");

                return contract;
            });
        }

        //protected override string ResolvePropertyName(string propertyName)
        //{
        //    return WrapForCS(() =>
        //    {
        //        WriteLine($"before ResolvePropertyName for property {propertyName}");
        //        var prop = base.ResolvePropertyName(propertyName);
        //        WriteLine($"after ResolvePropertyName for property {propertyName} -> {prop}");

        //        return prop;
        //    });
        //}
    }
}
