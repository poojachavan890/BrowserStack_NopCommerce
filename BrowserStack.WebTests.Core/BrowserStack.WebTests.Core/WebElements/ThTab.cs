using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThTab : ThElementBase
    {
        public ThTab(
            string cssSelector = null
        ) : base(cssSelector: cssSelector)
        {
            this.Tabs = new List<ThMenuItem>();
        }

        public void Click()
        {
            GetWebElement().Click();
        }

        public void ClickMenuOption(string menuText)
        {
            var menuItem = this.Tabs.FirstOrDefault(p => p.MenuText == menuText);
            if (menuItem == null)
            {
                StringBuilder sb = new StringBuilder();
                var availableMenuOptions = string.Join("\n", this.Tabs.Select(p => p.MenuText));
                throw new Exception("Menu item is not defined for " + menuText + "\nAvailable Options: \n" + availableMenuOptions);
            }
            menuItem.Click();
        }

        public void AssertMenuOption(string menuText)
        {
            var menuItem = this.Tabs.FirstOrDefault(p => p.MenuText == menuText);
            if (menuItem == null)
            {
                var availableMenuOptions = string.Join("\n", this.Tabs.Select(p => p.MenuText));
                throw new Exception("Menu item is not defined for " + menuText + "\nAvailable Options: \n" + availableMenuOptions);
            }
            menuItem.AssertIsVisible();
        }

        public List<ThMenuItem> Tabs { get; set; }
    }
}
