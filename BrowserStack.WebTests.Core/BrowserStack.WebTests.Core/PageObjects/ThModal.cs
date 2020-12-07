using Autofac;
using OpenQA.Selenium;
using System;
using System.Linq;
using BrowserStack.WebTests.Core.WebElements;

namespace BrowserStack.WebTests.Core.PageObjects
{
    public abstract class ThModal : IModal
    {
        protected ThModal()
        {
        }

        public IWebDriver Driver => WebTestSuiteBase.Container.Resolve<IWebDriver>();
        protected ITestConfiguration Configuration => WebTestSuiteBase.Container.Resolve<ITestConfiguration>();
        public abstract bool ModalIsVisible { get; }

        public virtual void BuildElements()
        {
            var props = GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ThElementBySelectorAttribute)));
            foreach (var propertyInfo in props)
            {
                var attribute = (ThElementBySelectorAttribute)propertyInfo
                    .GetCustomAttributes(typeof(ThElementBySelectorAttribute), true)
                    .First();
                var element = WebTestSuiteBase.Container.Resolve(propertyInfo.PropertyType,
                    new NamedParameter("cssSelector", attribute.CssSelector),
                    new NamedParameter("xpathSelector", attribute.XpathSelector));
                propertyInfo.SetValue(this, element);
            }
        }
    }
}
