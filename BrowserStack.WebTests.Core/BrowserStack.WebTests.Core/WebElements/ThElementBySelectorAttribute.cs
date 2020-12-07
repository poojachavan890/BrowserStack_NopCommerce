namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThElementBySelectorAttribute : System.Attribute
    {
        public string CssSelector { get; }
        public string XpathSelector { get; }

        public ThElementBySelectorAttribute(string cssSelector = null, string xpathSelector = null)
        {
            CssSelector = cssSelector;
            XpathSelector = xpathSelector;
        }
    }
}
