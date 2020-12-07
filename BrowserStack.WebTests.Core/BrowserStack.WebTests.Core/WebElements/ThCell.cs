using OpenQA.Selenium;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThCell
    {
        public ThCell(IWebElement element)
        {
            Element = element;
        }

        public IWebElement Element { get; set; }

        public void AssertText(string text)
        {
            // this.Element.Text == text;
        }
    }
}
