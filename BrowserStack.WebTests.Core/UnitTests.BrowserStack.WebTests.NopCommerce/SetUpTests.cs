using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using BrowserStack.WebTests.Core;
using BrowserStack.WebTests.NopCommerce.Autofac;
using BrowserStack.WebTests.NopCommerce.Site;
using BrowserStack.WebTests.NopCommerce.TestData;
using BrowserStack.WebTests.PrivilegeManager.TestData.Constants;
using BrowserStack.WebTests.NopCommerce.Common;

namespace UnitTests.BrowserStack.WebTests.NopCommerce
{
    [SetUpFixture]
    public class SetUpTests : SetupWebTestCore
    {
        protected NopCommerceSites NopCommerce { get; private set; }
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SetupAutofac();
            try
            {
                var testDataService = WebTestSuiteBase.Container.Resolve<TestDataService>();
                testDataService.LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed " + ex.Message);
            }
            NopCommerce = TestSuiteFixture.Container.Resolve<NopCommerceSites>();
            string browser = TestContext.Parameters.Get(Constant.BROWSER);
            string Environment = TestContext.Parameters.Get(Constant.ENVIRONMENT);
            switch (Environment)
            {
                case Constant.ONPREM:
                    LoginforOnPrem(browser);
                    break;

                case Constant.UPGRADE:
                    break;
            }
        }


        public void LoginforOnPrem(string browser)
        {
            this.NopCommerce.CommonPages.PMLogin.GoToPage();
            this.NopCommerce.Browser.MaximizeWindow();
            var login = this.NopCommerce.GetCurrentPage<Login>();

        }
    
        
        
        [OneTimeTearDown]
        public void NopCommercetearDown()
        {
            string env = TestContext.Parameters.Get(Constant.ENVIRONMENT);
           
        }

        protected override void SetupAutofac()
        {
            var builder = new ContainerBuilder();
            var testConfig = new TestConfiguration();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config-nopcommerce.json", false)
                .Build();
            Console.WriteLine("Autofac sucessfull");
            if (!string.IsNullOrEmpty(TestContext.Parameters.Get("browser")))
            {
                Dictionary<string, string> lstBaseQAUrls = new Dictionary<string, string>();
               
                lstBaseQAUrls.Add("BrowserStack.WebTests.NopCommerce", TestContext.Parameters.Get("baseQAUrl"));
                lstBaseQAUrls.Add("RegisterURL", TestContext.Parameters.Get("RegisterURL"));
                testConfig.Browser = TestContext.Parameters.Get("browser");
                testConfig.BaseQAUrl = TestContext.Parameters.Get("baseQAUrl");
                testConfig.AcceptInsecureCertificates = Convert.ToBoolean(TestContext.Parameters.Get("acceptInsecureCertificates"));
                testConfig.RemoteSeleniumServerUrl = TestContext.Parameters.Get("remoteSeleniumServerUrl");
                testConfig.TestDataFile = TestContext.Parameters.Get("testDataFile");
                testConfig.Environment = TestContext.Parameters.Get("Environment");
                testConfig.BaseQAUrls = lstBaseQAUrls;
            }
            else
            {
                testConfig = configuration.GetSection("site").Get<TestConfiguration>();
                Console.WriteLine("Run setting file  else");
            }
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
            builder.RegisterModule(new NopCommerceWebTestsModule(testConfig));
            RegisterModules(builder, testConfig);
            WebTestSuiteBase.Container = builder.Build();
        }


       


    }
}

