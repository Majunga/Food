using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Collections;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Common.HtmlBuilders
{
    public class DropdownBuilder : HtmlBuilderBase
    {
        private readonly SelectListItem _defaultSelectListItem = new SelectListItem("Nothing to select", string.Empty, true);
        public IHtmlContent CreateDropdown(List<SelectListItem> selectListItems, HtmlAttributes menuContainerAttributes = null)
        {
            if (menuContainerAttributes == null)
            {
                menuContainerAttributes = new HtmlAttributes();
            }

            menuContainerAttributes.AddClass("dropdown");

            var newSelectList = FormatList(selectListItems);
            var selectedItem = newSelectList.First(s => s.Selected);

            var dropdownButton = CreateDropdownButton(selectedItem);

            var dropdownItems = CreateDropdownItems(newSelectList);
            
            var dropdownMenu = this.CreateBasicElement(new List<IHtmlContent>(dropdownItems), "div",
                new HtmlAttributes("dropdown-menu",
                    otherAttributes: new Dictionary<string, string> {{"aria-labelledby", "dropdownMenuButton"}}));

            var menuContainer = this.CreateBasicElement(new List<IHtmlContent> {dropdownButton, dropdownMenu }, "div", menuContainerAttributes);
            return menuContainer;
        }

        private IEnumerable<IHtmlContent> CreateDropdownItems(List<SelectListItem> selectListItems)
        {
            foreach (var selectListItem in selectListItems)
            {
                yield return CreateDropdownItem(selectListItem);
            }
        }

        private IHtmlContent CreateDropdownItem(SelectListItem selectListItem)
        {
            var otherAttributes = new Dictionary<string, string>
            {
                {"href", "#"},
                { "value", selectListItem.Value }
            };

            if (selectListItem.Selected)
            {
                otherAttributes.Add("selected", "selected");
            }
            
            return CreateBasicElement(new List<IHtmlContent>(), "a", new HtmlAttributes("dropdown-item", otherAttributes:otherAttributes ), selectListItem.Text);
        }

        private IHtmlContent CreateDropdownButton(SelectListItem selectedItem)
        {
            var dropdownMenu = this.CreateBasicElement(new List<IHtmlContent>(), "button", new HtmlAttributes(
                    "btn dropdown-toggle", otherAttributes: new Dictionary<string, string>
                    {
                        {"type", "button"},
                        {"data-toggle", "dropdown"},
                        {"aria-haspopup", "true"},
                        {"aria-expanded", "false"},
                        {"value", selectedItem.Value}
                    }),
                selectedItem.Text
            );
            return dropdownMenu;
        }


        private List<SelectListItem> FormatList(List<SelectListItem> selectListItems)
        {
            var newSelectList = new List<SelectListItem>();
            
            if (selectListItems == null || selectListItems.Count == 0)
            {
                newSelectList.Add(_defaultSelectListItem);
                return newSelectList;
            }


            var selectedItem = selectListItems.FirstOrDefault(s => s.Selected);

            if (selectedItem == null)
            {
                selectedItem = selectListItems.First();
                selectedItem.Selected = true;
                newSelectList.Add(selectedItem);
            }

            foreach (var item in selectListItems)
            {
                newSelectList.Add(item);
            }

            return newSelectList;
        }
    }
}
