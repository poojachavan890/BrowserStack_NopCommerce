using OpenQA.Selenium;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThRow
    {
        public IWebElement Element { get; set; }
        public ThCell[] Cells { get; set; }
    }
}
