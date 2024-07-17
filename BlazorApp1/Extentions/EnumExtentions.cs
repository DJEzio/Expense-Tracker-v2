using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var enumName = Enum.GetName(enumType, enumValue);
        var memberInfo = enumType.GetField(enumName);
        var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute != null ? descriptionAttribute.Description : enumName;
    }
}
