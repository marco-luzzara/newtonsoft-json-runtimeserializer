using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Newtonsoft.Json.RuntimeSerializer.Utils
{
    public class PropertyProvider
    {
        // https://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
        public static PropertyInfo GetPropertyInfoFromExpr<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            PropertyInfo propInfo = ((propertyLambda.Body as MemberExpression)?
                .Member as PropertyInfo);

            if (propInfo == null)
                throw new ArgumentException($"{propertyLambda} must refer to a property");

            return propInfo;
        }

        public static PropertyInfo GetPropertyInfoFromName<T>(string propName)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return propInfo;
        }

        public static FieldInfo GetFieldInfoFromName<T>(string fieldName)
        {
            FieldInfo fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return fieldInfo;
        }
    }
}
