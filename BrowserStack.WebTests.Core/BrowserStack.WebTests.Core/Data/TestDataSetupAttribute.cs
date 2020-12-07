using Autofac;
using System;
using System.Threading.Tasks;

namespace BrowserStack.WebTests.Core.Data
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class TestDataSetupAttribute : Attribute, ITestDataSetupAttribute
    {
        public virtual async Task SetupDataAsync(ILifetimeScope scope)
        {
            await Task.Run(() => { });
        }

        public virtual async Task TearDownDataAsync(ILifetimeScope scope)
        {
            await Task.Run(() => { });
        }

        public abstract string GetDescription();
        public int Order { get; set; } = 9999;
    }
}
