namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThMenuItem : ThElementBase
    {
        public ThMenuItem(
            string menuText,
            string cssSelector = null,
            string xpathSelector = null
        ) : base(
            cssSelector: cssSelector,
            xpathSelector: xpathSelector
            )
        {
            this.MenuText = menuText;
        }

        public string MenuText { get; set; }

        public void Click()
        {
            GetWebElement().Click();
        }
    }
}
