using System;

namespace Bank_Project.Utility
{
    public class clsUtility
    {
        public static string ObjectToString(object obj) 
        {
            if (obj == null) return string.Empty;

            var properties = obj.GetType().GetProperties();

            var result = string.Join("#//#", properties.Select(p => p.GetValue(obj)?.ToString() ?? string.Empty));

            return result;
        }

        public static object ?StringToObject(string data, Type objectType)
        {
            if (string.IsNullOrEmpty(data)) return null;

            var obj = Activator.CreateInstance(objectType);

            var values = data.Split(new[] { "#//#" }, StringSplitOptions.None);

            var properties = objectType.GetProperties();

            for (int i = 0; i < properties.Length && i < values.Length; i++)
            {
                var property = properties[i];

                var convertedValue = Convert.ChangeType(values[i], property.PropertyType);
                property.SetValue(obj, convertedValue);
            }

            return obj;
        }

    }
}
