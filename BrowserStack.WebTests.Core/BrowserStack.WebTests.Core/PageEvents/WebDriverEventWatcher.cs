using Autofac;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace BrowserStack.WebTests.Core.PageEvents
{
    public class WebDriverEventWatcher
    {
        public WebDriverEventWatcher()
        {
        }

        public void Watch()
        {
            while (WebTestSuiteBase.Container == null || !WebTestSuiteBase.Container.IsRegistered<IWebDriver>())
            {
                Thread.Sleep(100);
            }

            try
            {
                var driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
                var currentUrl = "";
                WebDriverEventWatcher.Run = true;
                while (WebDriverEventWatcher.Run)
                {
                    var url = driver.Url;
                    if (url != currentUrl)
                    {
                        var driverEvent = new DriverEvent()
                        { DriverEventType = DriverEventType.UrlChange, EventData = url };
                        RaiseDriverEvent(driverEvent);
                    }

                    currentUrl = url;
                    Thread.Sleep(100);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static bool Run { get; set; }
        public static event EventHandler<DriverEvent> DriverEvent;
        private static void RaiseDriverEvent(DriverEvent driverEvent)
        {
            DriverEvent?.Invoke(null, driverEvent);
        }
    }
}
