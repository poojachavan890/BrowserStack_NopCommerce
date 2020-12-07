using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThTextElement : ThElementBase
    {
        public ThTextElement(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector, xpathSelector: xpathSelector)
        {
        }

        public string Text => GetWebElement().Text;

        public void AssertElementHasCssClass(string cssClassName)
        {
            var element = GetWebElement();
            var css = element.GetAttribute("class");
            var classNames = css.Split(' ');
            var foundClass = false;
            foreach (var className in classNames)
            {
                if (string.Equals(cssClassName, className, StringComparison.OrdinalIgnoreCase))
                {
                    foundClass = true;
                    break;
                }
            }

            if (!foundClass)
            {
                Assert.Fail($"Expected element {Selector.ToString()} on {this.Driver.Url} to have class '{cssClassName}' and it did not.");
            }
        }

        /// <summary>
        /// Assert that the element contains the passed text using TextToBePresentInElement and appropriate waits
        /// </summary>
        /// <param name="s"></param>
        public void AssertText(string s)
        {
            var waitSeconds = 5;
            var element = GetWebElement();
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(waitSeconds));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(this.Selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be EXIST after waiting {waitSeconds} seconds on {this.Driver.Url}");
            }

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(this.Selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be VISIBLE after waiting {waitSeconds} seconds on {this.Driver.Url}");
            }

            try
            {
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, s));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to CONTAIN TEXT '{s}' after waiting {waitSeconds} seconds on {this.Driver.Url}");
            }
        }
    }
}
