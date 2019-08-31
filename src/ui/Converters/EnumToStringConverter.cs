using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace StartPagePlus.UI.Converters
{
    public class EnumToStringConverter<T> : EnumConverter
        where T : struct
    {
        private static readonly Dictionary<T, string> toString = new Dictionary<T, string>();

        private static readonly Dictionary<string, T> toValue = new Dictionary<string, T>();

        private static bool isInitialized;

        static EnumToStringConverter()
            => Debug.Assert(typeof(T).IsEnum, "The custom enum class must be used with an enum type.");

        public EnumToStringConverter() : base(typeof(T))
        {
            if (isInitialized)
            {
                return;
            }

            Initialize();

            isInitialized = true;
        }

        protected void Initialize()
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                var description = GetDescription(item);

                toString[item] = description;
                toValue[description] = item;
            }
        }

        private static string GetDescription(T optionValue)
        {
            var optionDescription = optionValue.ToString();
            var optionInfo = typeof(T).GetField(optionDescription);

            if (Attribute.IsDefined(optionInfo, typeof(DescriptionAttribute)))
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(optionInfo, typeof(DescriptionAttribute));
                return attribute.Description;
            }

            return optionDescription;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var optionValue = (T)value;

            return (destinationType == typeof(string)) && toString.ContainsKey(optionValue)
                ? toString[optionValue]
                : base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;

            return !string.IsNullOrEmpty(stringValue) && toValue.ContainsKey(stringValue)
                ? toValue[stringValue]
                : base.ConvertFrom(context, culture, value);
        }
    }
}