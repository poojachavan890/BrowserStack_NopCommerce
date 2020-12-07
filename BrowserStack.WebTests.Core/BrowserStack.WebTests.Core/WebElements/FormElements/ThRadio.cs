using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements.FormElements
{
    public class ThRadio : ThFormInputBase, IThElement
    {
        public ThRadio(string cssSelector = null, string xpathSelector = null) :
            base(cssSelector: cssSelector, xpathSelector: xpathSelector)
        {

        }

        public bool Checked
        {
            get
            {
                var element = GetWebElement();
                return element.GetAttribute("checked") == "checked";
            }
            set
            {
                if (this.Checked == value)
                {
                    return;
                }
                var element = GetWebElement();
                var waitTime = 30;
                var wait = new WebDriverWait(this.Driver, new TimeSpan(0, 0, waitTime));
                try
                {
                    wait.Until<bool>((d) => element.Enabled);
                }
                catch (WebDriverTimeoutException wex)
                {
                    throw new Exception($"Radio failed for {Selector?.ToString()}.  Never was ENABLED after {waitTime} seconds on page {this.Driver.Url}", wex);
                }
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                }
                catch (WebDriverTimeoutException wex)
                {
                    throw new Exception($"Radio failed for {Selector?.ToString()}.  Never was CLICKABLE after {waitTime} seconds on page {this.Driver.Url}", wex);
                }
                element.Click();
            }
        }

        public override string Value
        {
            get => this.Checked.ToString();
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("must be True or False");
                }

                bool b = value.ToLower() == "true";

                this.Checked = b;
            }
        }
    }
}
