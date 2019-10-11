using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Collections;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Common.HtmlBuilders
{
    public class HtmlBuilderBase
    {
        protected TagHelperOutput CreateTagHelperOutput(string tagName)
        {
            return new TagHelperOutput(
                tagName: tagName,
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (s, t) =>
                {
                    return Task.Factory.StartNew<TagHelperContent>(
                        () => new DefaultTagHelperContent());
                }
            );
        }
        
        protected IHtmlContent CreateBasicElement(
            List<IHtmlContent> elements,
            string elementType,
            HtmlAttributes attributes = null,
            string value = "")
        {
            var newElement = new TagBuilder(elementType);
            attributes = attributes ?? new HtmlAttributes();
            if (attributes.Has(AttributeType.Class))
            {
                newElement.AddCssClass(attributes.Value(AttributeType.Class));
            }


            foreach (var attribute in attributes)
            {
                if (attribute.Key == AttributeType.Class.ToKey())
                {
                    continue;
                }

                newElement.Attributes.Add(attribute.Key, attribute.Value);
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                newElement.InnerHtml.Append(value);
            }

            foreach (var element in elements)
            {
                newElement.InnerHtml.AppendHtml(element);
            }

            return newElement;
        }
    }
}