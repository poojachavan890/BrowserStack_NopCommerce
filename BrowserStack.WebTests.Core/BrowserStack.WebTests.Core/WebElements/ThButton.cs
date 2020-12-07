using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThButton : ThElementBase
    {
        public ThButton() : base()
        {

        }

        public ThButton(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector, xpathSelector: xpathSelector)
        {

        }

        public virtual void Click()
        {
            var element = GetWebElement();
            var waitTime = 30;
            var wait = new WebDriverWait(this.Driver, new TimeSpan(0, 0, waitTime));
            try
            {
                wait.Until<bool>((d) => element.Enabled);
            }
            catch (WebDriverTimeoutException wex)
            {
                throw new Exception($"Click failed for {Selector?.ToString()}.  Never was ENABLED after {waitTime} seconds on page {this.Driver.Url}", wex);
            }
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException wex)
            {
                throw new Exception($"Click failed for {Selector?.ToString()}.  Never was CLICKABLE after {waitTime} seconds on page {this.Driver.Url}", wex);
            }
            element.Click();
        }

        public string Text
        {
            get { return this.GetWebElement().Text; }
        }
    }
}
