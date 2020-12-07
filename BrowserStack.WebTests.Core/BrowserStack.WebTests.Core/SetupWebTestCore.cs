using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using BrowserStack.WebTests.Core.Autofac;
using BrowserStack.WebTests.Core.PageEvents;

namespace BrowserStack.WebTests.Core
{
    [SetUpFixture]
    public class SetupWebTestCore
    {
        [OneTimeSetUp]
        public virtual void OneTimeSetupCore()
        {
            StartEvents();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDownCore()
        {
            WebDriverEventWatcher.Run = false;

            try
            {
                WebTestSuiteBase.Container.Resolve<IWebDriver>().Close();
            }
            catch { }

            WebTestSuiteBase.Container.Resolve<IWebDriver>().Quit();
        }

        protected virtual void SetupAutofac()
        {
            var builder = new ContainerBuilder();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", false)
                .Build();

            var testConfig = configuration.GetSection("site").Get<TestConfiguration>();
            if (!string.IsNullOrWhiteSpace(testConfig.BaseQAUrl) && testConfig.BaseQAUrl.EndsWith("/"))
            {
                throw new Exception("BaseQAUrl in config.json should not end with a slash");
            }

            if (testConfig.BaseQAUrls != null)
            {
                foreach (var key in testConfig.BaseQAUrls.Keys)
                {
                    var url = testConfig.BaseQAUrls[key];
                    if (!string.IsNullOrWhiteSpace(url) && url.EndsWith("/"))
                    {
                        throw new Exception($"BaseQAUrls.{key} in config.json should not end with a slash");
                    }
                }
            }

            builder.RegisterInstance(testConfig).As<ITestConfiguration>();
            builder.RegisterModule(new CoreWebTestModule(testConfig));
            RegisterModules(builder, testConfig);

            WebTestSuiteBase.Container = builder.Build();
        }

        private void StartEvents()
        {
            WebDriverEventWatcher.DriverEvent += WebDriverEventWatcher_DriverEvent;
            Thread t = new Thread(new WebDriverEventWatcher().Watch);
            t.Start();
        }

        protected virtual void RegisterModules(ContainerBuilder builder, TestConfiguration configuration)
        {
            builder.RegisterModule(new CoreWebTestModule(configuration));
        }

        protected virtual void WebDriverEventWatcher_DriverEvent(object sender, DriverEvent e)
        {

        }
    }
}
