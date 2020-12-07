using System;

namespace BrowserStack.WebTests.Core.WebElements.FormElements
{
    public class ThCheckbox : ThFormInputBase, IThElement
    {
        public ThCheckbox() : base()
        {

        }
        public ThCheckbox(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector,
           xpathSelector: xpathSelector)
        {

        }



        public bool Checked
        {
            get
            {
                var element = GetWebElement();
                if (element.Displayed)
                {
                    if (!element.Selected)
                    {
                        return false;
                    }
                }

                return true;
            }
            set
            {
                if (this.Checked == value)
                {
                    return;
                }
                var element = GetWebElement();
                if (element.Displayed)
                {
                    element.Click();
                    return;
                }
            }
        }

        public override string Value
        {
            get => this.Checked.ToString();
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("must be True or False");
                }

                bool b = value.ToLower() == "true";

                this.Checked = b;
            }
        }
    }
}
