using System;
using System.Linq;
using System.Reflection;

namespace CmsProject.Utilities.EnumObject
{
    public static class ObjectExtension
    {
        public static string TitleEnum<TEnum>(this TEnum item) where TEnum : struct, IConvertible
        {
            if (!Enum.IsDefined(item.GetType(), item))
                return string.Empty;
            var enumMetadataAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<TitleAtribute>().FirstOrDefault();
            if (enumMetadataAttrib != null)
                return enumMetadataAttrib.Title;
            else
                return item.ToString();
        }
    }
}