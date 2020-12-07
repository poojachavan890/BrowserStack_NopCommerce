using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThElementBase : IThElement
    {
        public ThElementBase(string cssSelector = null, string xpathSelector = null)
        {
            if (cssSelector != null)
            {
                this.Selector = By.CssSelector(cssSelector);
            }

            if (xpathSelector != null)
            {
                this.Selector = By.XPath(xpathSelector);
            }
        }

        protected IWebElement GetWebElement()
        {
            return GetWebElement(this.Selector);
        }

        protected IWebElement GetWebElement(OpenQA.Selenium.By selector)
        {
            if (WebElement != null)
            {
                return WebElement;
            }

            var waitTime = 15;
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(waitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"GetWebElement {Selector?.ToString()} failed to get element after {waitTime} seconds on page {this.Driver.Url}");
            }
            return Driver.FindElement(selector);
        }

        public void AssertIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(Selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be visible after waiting 15 seconds on {this.Driver.Url}");
            }
        }

        public bool ElementExists()
        {
            return Driver.FindElements(Selector).Count > 0;
        }

        public bool ElementDisplayed()
        {
            var element = Driver.FindElement(Selector);
            return element.Displayed;
        }

        public void AssertIsNotVisible()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be not visible after waiting 15 seconds on {this.Driver.Url}");
            }
        }
        public void RightClick()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(Selector));
            Actions action = new Actions(Driver);
            IWebElement ele = Driver.FindElement(Selector);
            action.ContextClick(ele).Perform();
        }

        public bool ElementIsEnabled()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(Selector));
            var element = GetWebElement();
            string val = element.GetAttribute("disabled");
            return string.IsNullOrEmpty(val);
        }

        public void SwitchToFrame()
        {
            Driver.SwitchTo().Frame(GetWebElement());
        }

        public void WaitForElementToVisible(int? timeOut = null)
        {
            if (timeOut == null)
            {
                timeOut = 30;
            }

            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(timeOut.Value));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(Selector));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be visible after waiting " + timeOut + " seconds on {this.Driver.Url}");
            }
        }

        public void MouseOver()
        {
            IWebDriver driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Selector));

            actions.MoveToElement(GetWebElement());
            actions.Perform();
        }

        public IWebDriver Driver => WebTestSuiteBase.Container.Resolve<IWebDriver>();
        public OpenQA.Selenium.By Selector { get; set; }
        public IWebElement WebElement { get; set; }
    }

}
