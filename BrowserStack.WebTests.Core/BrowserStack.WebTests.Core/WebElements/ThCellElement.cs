using OpenQA.Selenium;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThCellElement<T> where T : IThElement, new()
    {
        public T Element { get; set; }

        public void AssignCell(IWebElement element, By selector)
        {
            this.Element = new T
            {
                WebElement = element.FindElement(selector)
            };
        }
    }
}
