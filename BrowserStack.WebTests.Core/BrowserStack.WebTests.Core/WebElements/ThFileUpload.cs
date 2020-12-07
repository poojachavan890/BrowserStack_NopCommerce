using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThFileUpload : ThElementBase
    {
        public ThFileUpload(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector,
            xpathSelector: xpathSelector)
        {

        }

        public void UploadFile(string FilePath)
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(Selector));
                Driver.FindElement(Selector).SendKeys(FilePath);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Expected element {Selector?.ToString()} failed to be present after waiting 15 seconds on {this.Driver.Url}");
            }
        }

    }

}
