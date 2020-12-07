using Autofac;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using BrowserStack.WebTests.Core.Data;

namespace BrowserStack.WebTests.Core
{
    public class WebTestSuiteBase
    {
        public static IContainer Container { get; set; }

        [SetUp]
        public virtual async Task SetUp()
        {
            await PreSetupDataAsync();
            await RunDataSetupAsync(true);
            await PostSetupDataAsync();
        }

        public virtual Task PreSetupDataAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task PostSetupDataAsync()
        {
            return Task.CompletedTask;
        }

        [TearDown]
        public virtual async Task TearDown()
        {
            await PreTearDownAsync();
            await RunDataSetupAsync(false);
            await PostTearDownAsync();
        }

        public virtual Task PreTearDownAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task PostTearDownAsync()
        {
            return Task.CompletedTask;
        }

        private async Task RunDataSetupAsync(bool isSetup)
        {
            await RunClassSetupAsync(isSetup);
        }

        private async Task RunClassSetupAsync(bool isSetup)
        {
            var test = TestContext.CurrentContext.Test;
            var executingAssemblyFullName = GetType().Assembly.ManifestModule.Assembly.GetName();
            var fullyQualifiedTestClassName = test.ClassName + ", " + executingAssemblyFullName;
            var testFixtureClassType = Type.GetType(fullyQualifiedTestClassName);

            if (testFixtureClassType != null)
            {
                var classAttributes = testFixtureClassType.GetCustomAttributes(false);
                await RunSetupAttributes(isSetup, classAttributes, "class");

                var testMethod = testFixtureClassType.GetMethod(test.MethodName);
                if (testMethod != null)
                {
                    var methodAttributes = testMethod.GetCustomAttributes(false);
                    await RunSetupAttributes(isSetup, methodAttributes, "method");
                }
            }
        }

        private static async Task RunSetupAttributes(bool isSetup, object[] attributes, string scope)
        {
            using (var setupLifetimeScope = WebTestSuiteBase.Container.BeginLifetimeScope())
            {
                var sortedAttributes = attributes.OfType<TestDataSetupAttribute>().OrderBy(p => p.Order);

                foreach (var setupAttribute in sortedAttributes)
                {
                    try
                    {
                        if (isSetup)
                        {
                            await setupAttribute.SetupDataAsync(setupLifetimeScope);
                        }
                        else
                        {
                            await setupAttribute.TearDownDataAsync(setupLifetimeScope);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("********** Setup Scope: " + scope);
                        Console.WriteLine($"********* Failed Tear Down of Setup Data: {setupAttribute.GetDescription()}");
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine($"********* Failed End: {setupAttribute.GetDescription()}");
                        var step = isSetup ? "Setup" : "TearDown";
                        Assert.Fail($"Test '{step}' failed on '{setupAttribute.GetDescription()}': \n{ex.ToString()}");
                    }
                }
            }
        }
    }
}
