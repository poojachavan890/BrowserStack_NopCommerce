using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements.FormElements
{
    public class ThInput : ThFormInputBase, IThElement
    {

        public ThInput() : base()
        {

        }
        public ThInput(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector,
            xpathSelector: xpathSelector)
        {

        }

        public override string Value
        {
            get => GetWebElement().GetAttribute("value");
            set
            {
                var valueUpdated = false;
                var sanityCheck = 0;
                while (!valueUpdated && sanityCheck < 10)
                {
                    try
                    {
                        var element = GetWebElement();
                        WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
                        wait.Until(ExpectedConditions.ElementToBeClickable(element));
                        element.Click();
                        element.Clear();
                        element.SendKeys(value);
                        wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, value));
                        valueUpdated = true;
                    }
                    catch (StaleElementReferenceException)
                    {
                        sanityCheck++;
                        Thread.Sleep(200);
                    }
                }
            }
        }
    }
}
