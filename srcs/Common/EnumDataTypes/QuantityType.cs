using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Common.EnumDataTypes
{
    public enum QuantityType
    {
        [Display(Name="mls")]
        Millilitres,
        [Display(Name="l")]
        Litre,
        [Display(Name="g")]
        Gram,
        [Display(Name="kg")]
        Kilogram
    }

    public static class QuantityTypeExtensions
    {
        public static string GetFriendlyString(this QuantityType quantityType)
        {
            var fieldInfo = quantityType.GetType().GetField(quantityType.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if ((descriptionAttributes ?? throw new InvalidOperationException()).Any() && descriptionAttributes[0].ResourceType != null)
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : quantityType.ToString();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }
    }
}