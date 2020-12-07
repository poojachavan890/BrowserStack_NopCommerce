using OpenQA.Selenium.Support.UI;

namespace BrowserStack.WebTests.Core.WebElements.FormElements
{
    public class ThSelect : ThFormInputBase, IThElement
    {

        public ThSelect() : base()
        {

        }

        public ThSelect(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector, xpathSelector: xpathSelector)
        {

        }

        public virtual string Text
        {
            get
            {
                var select = new SelectElement(GetWebElement());
                return select.SelectedOption.Text;
            }
            set
            {
                var select = new SelectElement(GetWebElement());
                select.SelectByText(value);
            }
        }

        public override string Value
        {
            get
            {
                var select = new SelectElement(GetWebElement());
                return select.SelectedOption.GetAttribute("value");
            }
            set
            {
                var select = new SelectElement(GetWebElement());
                select.SelectByValue(value);
            }
        }
    }
}
