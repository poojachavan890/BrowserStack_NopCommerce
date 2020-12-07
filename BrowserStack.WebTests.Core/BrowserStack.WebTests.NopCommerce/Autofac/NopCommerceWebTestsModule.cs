using Autofac;
using System.Reflection;
using BrowserStack.WebTests.Core;
using BrowserStack.WebTests.Core.Autofac;
using BrowserStack.WebTests.Core.Site;
using BrowserStack.WebTests.NopCommerce.Site;
using BrowserStack.WebTests.NopCommerce.TestData;

namespace BrowserStack.WebTests.NopCommerce.Autofac
{
    public class NopCommerceWebTestsModule : WebTestSiteModule
    {
        private readonly ITestConfiguration _configuration;
        public NopCommerceWebTestsModule(ITestConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var testSiteAssembly = Assembly.GetAssembly(typeof(NopCommerceSites));
            RegisterCoreWebTypesInAssembly(builder, testSiteAssembly);
            builder.RegisterType<TestDataService>().AsSelf().SingleInstance();
        }

    }
}
