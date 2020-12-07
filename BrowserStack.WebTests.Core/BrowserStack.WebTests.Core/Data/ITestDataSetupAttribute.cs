using Autofac;
using System.Threading.Tasks;

namespace BrowserStack.WebTests.Core.Data
{
    public interface ITestDataSetupAttribute
    {
        Task SetupDataAsync(ILifetimeScope scope);
        string GetDescription();
    }
}
