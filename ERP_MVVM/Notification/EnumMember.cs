﻿using System;
using System.Collections.Generic;

namespace ERP_MVVM.Notification
{
    public class EnumMember
    {
        public string Description { get; set; }
        public int Value { get; set; }


        public static List<EnumMember> ConvertToList<T>()
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of type enumeration.");
            }

            var members = new List<EnumMember>();

            foreach (string item in System.Enum.GetNames(type))
            {
                var enumType = System.Enum.Parse(type, item);
                members.Add(new EnumMember() { Description = enumType.GetDescriptionValue(), Value = ((IConvertible)enumType).ToInt32(null) });
            }

            return members;
        }

    }
}
