using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace WebApiAngularJS.Domain.Enums
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
        public static List<T> GetList<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
        public static List<String> GetStringList<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(v => v.GetDescription()).ToList();
        }
    }
}
