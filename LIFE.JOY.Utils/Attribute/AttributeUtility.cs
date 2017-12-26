using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LIFE.JOY.Utils
{
    public static class AttributeUtility
    {
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            var attribute = type.GetCustomAttributes(typeof(T), true)
                .FirstOrDefault() as T;
            return attribute;
        }

        public static T GetAttribute<T>(this MemberInfo property) where T : Attribute
        {
            var attribute = property.GetCustomAttributes(typeof(T), true)
                .FirstOrDefault() as T;
            return attribute;
        }

        public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }

            return (T)attribute;
        }

        public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);

            var attr2 = memberInfo.GetCustomAttributes<System.ComponentModel.DataAnnotations.DisplayAttribute>(false);

            if (attr != null)
            {
                return attr.DisplayName;
            }

            if (attr2 != null && attr2.Count() > 0)
            {
                return attr2.First().Name;
            }

            return memberInfo.Name;
        }

        public static MemberInfo GetPropertyInformation(Expression propertyExpression)
        {
            Debug.Assert(propertyExpression != null, "propertyExpression != null");
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }
    }
}