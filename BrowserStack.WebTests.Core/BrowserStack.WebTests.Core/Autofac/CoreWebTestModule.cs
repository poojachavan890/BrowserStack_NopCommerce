using Autofac;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Reflection;
using BrowserStack.WebTests.Core.WebElements;
using Module = Autofac.Module;

namespace BrowserStack.WebTests.Core.Autofac
{
    public class CoreWebTestModule : Module
    {
        private readonly ITestConfiguration _configuration;

        public CoreWebTestModule(ITestConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = _configuration.AcceptInsecureCertificates,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
            };
            chromeOptions.AddArgument("no-sandbox");
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = _configuration.AcceptInsecureCertificates,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
            };
            firefoxOptions.SetPreference("browser.download.folderList", 1);
            firefoxOptions.SetPreference("browser.download.useDownloadDir", true);
            firefoxOptions.SetPreference("browser.helperApps.alwaysAsk.force", false);
            firefoxOptions.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            firefoxOptions.SetPreference("browser.download.manager.useWindow", false);
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv;application/json;application/pdf;application/zip;application/x-pdf");
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.openFile", "text/csv;application/json;application/pdf;application/x-pdf");
            firefoxOptions.SetPreference("browser.download.manager.focusWhenStarting", false);
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.openFile", "");
            firefoxOptions.SetPreference("browser.download.manager.showAlertOnComplete", false);
            firefoxOptions.SetPreference("browser.download.manager.closeWhenDone", true);
            firefoxOptions.SetPreference("pdfjs.disabled", true);
            var IEOptions = new InternetExplorerOptions
            {
                AcceptInsecureCertificates = _configuration.AcceptInsecureCertificates,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
            };
            IEOptions.IgnoreZoomLevel = true;
            IEOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IEOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            IEOptions.EnableNativeEvents = false;
            IEOptions.EnablePersistentHover = true;
            IEOptions.RequireWindowFocus = true;
            IEOptions.EnsureCleanSession = true;

            var EdgeOptions = new EdgeOptions
            {
                AcceptInsecureCertificates = _configuration.AcceptInsecureCertificates,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept

            };
            EdgeOptions.UseChromium = true;
            if (!string.IsNullOrEmpty(_configuration.RemoteSeleniumServerUrl))
            {
                string USERNAME = "poojachavan1";
                string AUTOMATE_KEY = "f9jzV6LHWZNCCQUeW3pY";                
                DesiredCapabilities caps = new DesiredCapabilities();
                caps.SetCapability("os", "Windows");
                caps.SetCapability("os_version", "10");
                caps.SetCapability("browser", "Chrome");
                caps.SetCapability("browser_version", "80");
                caps.SetCapability("browserstack.user", USERNAME);
                caps.SetCapability("browserstack.key", AUTOMATE_KEY);
                caps.SetCapability("name", "NopCommerce Demo");
                caps.SetCapability("browserstack.idleTimeout", "300");
               
                builder.RegisterType<RemoteWebDriver>()
              .WithParameter(new TypedParameter(typeof(Uri), new Uri("https://" + USERNAME + ":" + AUTOMATE_KEY + "@hub-cloud.browserstack.com/wd/hub")))
              .WithParameter(new TypedParameter(typeof(ChromeOptions), caps))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
                var driver = new RemoteWebDriver(new Uri("https://" + USERNAME + ":" + AUTOMATE_KEY + "@hub-cloud.browserstack.com/wd/hub"), caps, TimeSpan.FromSeconds(600));
                builder.RegisterInstance(driver).AsImplementedInterfaces().SingleInstance();
            }
            else
            {
                if (!string.IsNullOrEmpty(_configuration.Browser)
                    && _configuration.Browser.Equals("Firefox"))
                {
                    // https://github.com/SeleniumHQ/selenium/issues/6597
                    string geckoDriverDirectory = ".";
                    FirefoxDriverService geckoService =
                        FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
                    geckoService.Host = "::1";

                    var driver = new FirefoxDriver(geckoService, firefoxOptions);
                    builder.RegisterInstance(driver).AsImplementedInterfaces().SingleInstance();
                }
                else if (!string.IsNullOrEmpty(_configuration.Browser)
                    && _configuration.Browser.Equals("Safari"))
                {
                    string safariDriverDirectory = "/usr/bin";
                    SafariDriverService safariService =
                        SafariDriverService.CreateDefaultService(safariDriverDirectory);

                    var driver = new SafariDriver(safariService);
                    builder.RegisterInstance(driver).AsImplementedInterfaces().SingleInstance();
                }
                else if (!string.IsNullOrEmpty(_configuration.Browser)
                    && _configuration.Browser.Equals("Chrome"))
                {
                    builder.RegisterType<ChromeDriver>()
                        .WithParameter(new TypedParameter(typeof(string), "."))
                        .WithParameter(new TypedParameter(typeof(ChromeOptions), chromeOptions))
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
                }
                else if (!string.IsNullOrEmpty(_configuration.Browser)
                    && _configuration.Browser.Equals("IE"))
                {
                    builder.RegisterType<InternetExplorerDriver>()
                        .WithParameter(new TypedParameter(typeof(string), "."))
                        .WithParameter(new TypedParameter(typeof(InternetExplorerOptions), IEOptions))
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
                }
                else if (!string.IsNullOrEmpty(_configuration.Browser)
                    && _configuration.Browser.Equals("Edge"))
                {
                    builder.RegisterType<EdgeDriver>()
                        .WithParameter(new TypedParameter(typeof(string), "."))
                        .WithParameter(new TypedParameter(typeof(EdgeOptions), EdgeOptions))
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
                }
            }

            var testSiteAssembly = Assembly.GetAssembly(typeof(ThElementBase));
            builder.RegisterAssemblyTypes(testSiteAssembly).Where(t => typeof(ThElementBase).IsAssignableFrom(t)).InstancePerDependency().AsSelf();
        }
    }
}
