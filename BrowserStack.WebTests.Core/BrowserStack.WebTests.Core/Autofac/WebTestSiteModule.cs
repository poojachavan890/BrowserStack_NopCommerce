using Autofac;
using System.Reflection;
using BrowserStack.WebTests.Core.PageObjects;
using BrowserStack.WebTests.Core.Site;
using BrowserStack.WebTests.Core.WebElements;
using Module = Autofac.Module;

namespace BrowserStack.WebTests.Core.Autofac
{
    public class WebTestSiteModule : Module
    {
        /// <summary>
        /// Register all core web ui item types
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assembly"></param>
        protected void RegisterCoreWebTypesInAssembly(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly).Where(t => typeof(ThElementBase).IsAssignableFrom(t)).InstancePerDependency().AsSelf();

            builder.RegisterAssemblyTypes(assembly).Where(t => typeof(IModal).IsAssignableFrom(t))
                .InstancePerLifetimeScope().AsSelf().OnActivated(a => ((IModal)a.Instance).BuildElements()); ;
            builder.RegisterAssemblyTypes(assembly).Where(t => typeof(IPageSection).IsAssignableFrom(t))
                .InstancePerLifetimeScope().AsSelf();
            builder.RegisterAssemblyTypes(assembly).Where(t => typeof(IPage).IsAssignableFrom(t))
                .InstancePerLifetimeScope().AsSelf().OnActivated(a => ((IPage)a.Instance).BuildElements()); ;
            builder.RegisterAssemblyTypes(assembly).Where(t => typeof(ITestWebSite).IsAssignableFrom(t))
                .InstancePerLifetimeScope().AsSelf();
        }
    }
}
