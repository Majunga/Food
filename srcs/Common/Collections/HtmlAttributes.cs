using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Common.Collections
{
    public class HtmlAttributes : AttributeDictionary
    {
        public HtmlAttributes()
        {

        }

        public HtmlAttributes(string classes = "", string styles = "", Dictionary<string, string> otherAttributes = null)
        {
            if (!string.IsNullOrWhiteSpace(classes))
            {
                this.AddClass(classes);
            }
            if (!string.IsNullOrWhiteSpace(styles))
            {
                this.AddStyle(styles);
            }

            if (otherAttributes != null)
            {
                foreach (var data in otherAttributes)
                {
                    this.AddAttribute(data.Key, data.Value);

                }
            }
        }

        private void AddAttribute(string attributeName, string attributeValue)
        {
            this.Add(attributeName, attributeValue);
        }

        public void AddClass(string values)
        {
            if (Has(AttributeType.Class))
            {
                var currentValue = this[AttributeType.Class.ToKey()];
                this[AttributeType.Class.ToKey()] = $"{currentValue} {values}";
            }
            else
            {
                this.Add(AttributeType.Class.ToKey(), values);
            }
        }

        public void AddStyle(string values)
        {
            this.Add(AttributeType.Style.ToKey(), values);
        }

        public bool Has(AttributeType type)
        {
            return this.Any(a => a.Key == type.ToKey());
        }

        public string Value(AttributeType type)
        {
            if (Has(type))
            {
                return this[type.ToKey()];
            }

            return string.Empty;
        }
    }

    public static class HtmlAttributesExtensions
    {
        internal static string ToKey(this AttributeType type)
        {
            return type.ToString().ToLowerInvariant();
        }
    }

    public enum AttributeType
    {
        Undefined,
        Class,
        Style,
        Data
    }
}
