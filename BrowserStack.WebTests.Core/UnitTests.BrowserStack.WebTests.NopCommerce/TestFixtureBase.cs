using Autofac;
using BrowserStack.WebTests.NopCommerce.Site;
using BrowserStack.WebTests.NopCommerce.TestData;
using BrowserStack.WebTests.NopCommerce.TestData.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests.BrowserStack.WebTests.NopCommerce
{
    [TestFixture]
    public class TestFixtureBase : TestSuiteFixture
    {
        protected NopCommerceSites NopCommerce { get; private set; }

        protected TestData Data { get; private set; }

        [SetUp]
        public override async Task SetUp()
        {
            NopCommerce = TestSuiteFixture.Container.Resolve<NopCommerceSites>();
            Data = TestSuiteFixture.Container.Resolve<TestDataService>().Data;
            await base.SetUp();
           
        }
        public void CaptureScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                this.NopCommerce.Home.TakeScreenShot(@"C:\Automation\Logs\Screenshot", TestContext.CurrentContext.Test.MethodName);
            }
        }
       
       
       
        [TearDown]
        public void PostExecutionSteps()
        {
            
            CaptureScreenshot();
        }

    }
}
