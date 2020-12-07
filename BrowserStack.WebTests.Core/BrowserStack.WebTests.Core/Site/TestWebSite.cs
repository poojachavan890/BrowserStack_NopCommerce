using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using BrowserStack.WebTests.Core.PageObjects;

namespace BrowserStack.WebTests.Core.Site
{
    public abstract class TestWebSite : ITestWebSite
    {
        private readonly IComponentContext _context;
        private ITestConfiguration _configuration;

        public TestWebSite(IComponentContext context)
        {
            _context = context;
        }

        //  get current page <IPage>
        public void AssertCurrentPage(IPage page)
        {

        }

        public bool IsModalOpen<T>() where T : IModal
        {
            var driver = _context.Resolve<IWebDriver>();
            try
            {
                var modal = _context.Resolve<T>();
                if (modal.ModalIsVisible)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        public T GetCurrentModal<T>()
            where T : IModal
        {
            var driver = _context.Resolve<IWebDriver>();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            var expectedModal = _context.Resolve<T>();

            wait.Until<bool>((d) => expectedModal.ModalIsVisible);

            return expectedModal;
        }

        public T GetCurrentPage<T>()
            where T : IPage
        {
            var driver = _context.Resolve<IWebDriver>();
            var expectedPage = _context.Resolve<T>();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, expectedPage.PageLoadTimeout));
            if (expectedPage.IsRouteComparisonAllowed)
            {
                try
                {
                    wait.Until<bool>((d) => IsRouteMatch(d, expectedPage));
                }
                catch (WebDriverTimeoutException)
                {
                    throw new Exception($"Route match timed out after {expectedPage.PageLoadTimeout} seconds waiting for {expectedPage.Route}.  Actual url is {driver.Url}");
                }
            }
            if (expectedPage.IsAngular)
            {
                WaitForAngular();
            }

            if (expectedPage.ElementVisibleAfterLoad != null)
            {
                try
                {
                    wait.Until(d => driver.FindElement(expectedPage.ElementVisibleAfterLoad));
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail($"Did not find expected element {expectedPage.ElementVisibleAfterLoad?.ToString()} GetCurrentPage at {driver.Url}");
                }
            }

            return expectedPage;
        }

        private bool IsRouteMatch(IWebDriver driver, IPage page)
        {
            var route = page.Route;
            var url = driver.Url.Substring(page.BaseUrl.Length);
            // Console.WriteLine($"Waiting for: {route} --- Currently On: {url}");

            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            var urlParts = url.Split('?')[0].Split('/');
            var routeParts = route.Split('?')[0].Split('/');
            for (var i = 0; i < routeParts.Length; i++)
            {
                var routePart = routeParts[i];
                if (routePart.Contains("{") && routePart.Contains("}"))
                {
                    continue;
                }

                if (string.Equals(routePart, urlParts[i], StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        public void WaitForAngular()
        {
            var driver = _context.Resolve<IWebDriver>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            var sanity = 0;
            var hasLoaded = false;
            while (!hasLoaded)
            {
                try
                {
                    hasLoaded = (bool)js.ExecuteScript("return window.getAllAngularTestabilities().length > 0");
                }
                catch (Exception)
                {
                    Console.WriteLine("Waiting for Angular to load");
                }
                Thread.Sleep(500);
                sanity++;
                if (sanity >= 60)
                {
                    Assert.Fail($"Timed out waiting for angular to load on {driver.Url}");
                }
            }
        }

        private ITestConfiguration Configuration
        {
            get
            {
                return _configuration ?? (_configuration = _context.Resolve<ITestConfiguration>());
            }
        }

        public ThBrowserService Browser => new ThBrowserService();
    }
}
