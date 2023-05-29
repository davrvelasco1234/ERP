
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ERP_MVVM.Notification
{
    public static class ExtensionMethods
    {
        public static List<EnumMember> ConvertToList(this System.Enum type)
        {
            var members = new List<EnumMember>();
            var enumType = type.GetType();

            System.Enum
                  .GetNames(type.GetType())
                  .ToList()
                  .ForEach(s => members.Add(new EnumMember() { Value = (int)(IConvertible)System.Enum.Parse(enumType, s), Description = s.GetDescriptionValue() }));

            return members.OrderBy(m => m.Description).ToList();
        }

        public static string GetDescriptionValue<T>(this T source)
        {
            FieldInfo fileInfo = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fileInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }
    }
}
