using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThLabel : ThTextElement
    {

        public ThLabel() : base()
        {

        }
        public ThLabel(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector,
            xpathSelector: xpathSelector)
        {

        }

        public void Click()
        {
            var element = GetWebElement();
            var wait = new WebDriverWait(this.Driver, new TimeSpan(0, 0, 10));
            wait.Until<bool>((d) => element.Enabled);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            GetWebElement().Click();
        }

    }
}
