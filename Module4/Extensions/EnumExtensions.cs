using Module4.Models;
using System.ComponentModel;
using System.Reflection;

namespace Module4.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? @enum.ToString();
        }
        public static EUnitOfMeasurement ToDescriptionType(this string @enum)
        {
            EUnitOfMeasurement eUnitOfMeasurement = (EUnitOfMeasurement)Enum.Parse(typeof(EUnitOfMeasurement), @enum);   
            return eUnitOfMeasurement;
        }
    }
}
