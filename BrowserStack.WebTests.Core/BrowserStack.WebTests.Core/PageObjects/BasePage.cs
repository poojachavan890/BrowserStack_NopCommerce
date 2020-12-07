using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.Linq;
using BrowserStack.WebTests.Core.Exceptions;
using BrowserStack.WebTests.Core.WebElements;

namespace BrowserStack.WebTests.Core.PageObjects
{
    public abstract class BasePage : IPage
    {
        private int? _timeout = null;
        private string _baseUrl = null;

        protected BasePage()
        {
        }

        public abstract string Route { get; }
        public abstract bool IsAngular { get; }
        public OpenQA.Selenium.By ElementVisibleAfterLoad { get; set; }
        public virtual bool IsRouteComparisonAllowed { get; set; } = true;

        /// <summary>
        /// This method is called immediately at the end of GoToPage.  It can be overriden to trigger events immediately after the page loads
        /// </summary>
        protected virtual void OnGotoPage()
        {

        }

        /// <summary>
        /// Navigate to a specific page.  Afterwards get current page to have it wait accordingly
        /// </summary>
        /// <param name="routeParameters"></param>
        public void GoToPage(dynamic routeParameters = null)
        {
            var route = this.Route;
            if (routeParameters != null && route.Contains("{") && route.Contains("}"))
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(routeParameters))
                {
                    var propertyInfo = routeParameters.GetType().GetProperty(property.Name);
                    var value = propertyInfo.GetValue(routeParameters, null);
                    if (value == null)
                    {
                        Assert.Fail($"Expected route parameter {property.Name} cannot be null for the route {this.Route}");
                    }
                    route = route.Replace($"{{{property.Name}}}", value.ToString());
                }
            }

            try
            {
                this.Driver.Navigate().GoToUrl(this.BaseUrl + route);
            }
            catch (WebDriverException wex)
            {
                if (!string.IsNullOrWhiteSpace(wex.Message) &&
                    wex.Message.Contains("Malformed URL: can't access dead object"))
                {
                    // when a page switches to a frame and then doesn't switch back this happens
                    this.Driver.SwitchTo().DefaultContent();
                    this.Driver.Navigate().GoToUrl(this.BaseUrl + route);
                }
                else
                {
                    throw;
                }
            }

            if (this.ElementVisibleAfterLoad != null)
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.PageLoadTimeout));
                try
                {
                    wait.Until(driver => driver.FindElement(this.ElementVisibleAfterLoad));
                }
                catch (WebDriverTimeoutException)
                {
                    throw new PageNotLoadedException(this.ElementVisibleAfterLoad, this.Driver.Url.ToString(), this.Route);
                }

            }

            OnGotoPage();
        }

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

        public IWebDriver Driver => WebTestSuiteBase.Container.Resolve<IWebDriver>();
        protected ITestConfiguration Configuration => WebTestSuiteBase.Container.Resolve<ITestConfiguration>();

        /// <summary>
        /// After calling GoToPage this is how long to wait until an element is visible after load
        /// </summary>
        public virtual int PageLoadTimeout
        {
            get
            {
                if (_timeout == null)
                {
                    _timeout = 30;
                    var config = WebTestSuiteBase.Container.Resolve<ITestConfiguration>();
                    if (config.PageLoadTimeout.HasValue)
                    {
                        _timeout = config.PageLoadTimeout.Value;
                    }

                    if (_timeout < 5)
                    {
                        _timeout = 30;
                    }
                }

                return _timeout.Value;
            }
        }

        /// <summary>
        /// 1 - Returns the setting from config.json in baseQAUrls that matches the assembly in which the page resides.
        /// 2 - Returns baseQAUrls from config.json
        /// </summary>
        public virtual string BaseUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_baseUrl))
                {
                    return _baseUrl;
                }

                var assemblyName = this.GetType().Assembly.GetName().Name;
                if (this.Configuration.BaseQAUrls != null && this.Configuration.BaseQAUrls.ContainsKey(assemblyName))
                {
                    _baseUrl = this.Configuration.BaseQAUrls[assemblyName];
                }
                else
                {
                    _baseUrl = this.Configuration.BaseQAUrl;
                }

                return _baseUrl;
            }
        }
    }
}
