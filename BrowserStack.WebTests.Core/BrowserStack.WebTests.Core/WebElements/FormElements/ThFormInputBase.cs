using NUnit.Framework;

namespace BrowserStack.WebTests.Core.WebElements.FormElements
{
    public abstract class ThFormInputBase : ThElementBase
    {
        public ThFormInputBase(string cssSelector = null, string xpathSelector = null) : base(cssSelector: cssSelector,
            xpathSelector: xpathSelector)
        {

        }

        public abstract string Value { get; set; }

        public void AssertValue(string expectedValue)
        {
            var value = this.Value;
            Assert.AreEqual(
                expectedValue,
                value,
                $"Expected element {Selector?.ToString()} value to be {expectedValue} but was {value} on {this.Driver.Url}"
                );
        }
    }
}
