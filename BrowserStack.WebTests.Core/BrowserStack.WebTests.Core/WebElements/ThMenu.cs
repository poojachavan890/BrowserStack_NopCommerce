using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThMenu : ThElementBase
    {
        public ThMenu(
            string cssSelector = null, string xpathSelector = null
            ) : base(cssSelector: cssSelector, xpathSelector: xpathSelector)
        {
            this.MenuItems = new List<ThMenuItem>();
        }

        public void Click()
        {
            GetWebElement().Click();
        }

        public void ClickMenuOption(string menuText)
        {
            var menuItem = this.MenuItems.FirstOrDefault(p => p.MenuText == menuText);
            if (menuItem == null)
            {
                StringBuilder sb = new StringBuilder();
                var availableMenuOptions = string.Join("\n", this.MenuItems.Select(p => p.MenuText));
                throw new Exception("Menu item is not defined for " + menuText + "\nAvailable Options: \n" + availableMenuOptions);
            }
            menuItem.WaitForElementToVisible();
            menuItem.Click();
        }

        public void AssertMenuOption(string menuText)
        {
            var menuItem = this.MenuItems.FirstOrDefault(p => p.MenuText == menuText);
            if (menuItem == null)
            {
                StringBuilder sb = new StringBuilder();
                var availableMenuOptions = string.Join("\n", this.MenuItems.Select(p => p.MenuText));
                throw new Exception("Menu item is not defined for " + menuText + "\nAvailable Options: \n" + availableMenuOptions);
            }
            menuItem.AssertIsVisible();
        }

        public void AssertMenuOptionIsNotVisibile(string menuText)
        {
            var menuItem = this.MenuItems.FirstOrDefault(p => p.MenuText == menuText);
            if (menuItem == null)
            {
                StringBuilder sb = new StringBuilder();
                var availableMenuOptions = string.Join("\n", this.MenuItems.Select(p => p.MenuText));
                throw new Exception("Menu item is not defined for " + menuText + "\nAvailable Options: \n" + availableMenuOptions);
            }
            menuItem.AssertIsNotVisible();
        }
        public List<ThMenuItem> MenuItems { get; set; }
    }
}
