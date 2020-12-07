using OpenQA.Selenium;

namespace BrowserStack.WebTests.Core.WebElements
{
    public interface IThElement
    {
        IWebDriver Driver { get; }
        OpenQA.Selenium.By Selector { get; set; }
        IWebElement WebElement { get; set; }
    }
}
