using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Newtonsoft.Json.RuntimeSerializer.Utils
{
    public class PropertyProvider
    {
        // https://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
        public PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            PropertyInfo propInfo = ((propertyLambda.Body as MemberExpression)?
                .Member as PropertyInfo);

            if (propInfo == null)
                throw new ArgumentException($"{propertyLambda} must refer to a property");

            return propInfo;
        }
    }
}
