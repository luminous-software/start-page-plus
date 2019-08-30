using System;
using System.ComponentModel;

namespace Luminous.Code.Enums
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            //https://stackoverflow.com/questions/1415140/can-my-enums-have-friendly-names

            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }
    }
}