using Autofac;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace BrowserStack.WebTests.Core.Site
{
    public class ThBrowserService
    {
        public ThBrowserService()
        {

        }

        public void MaximizeWindow()
        {
            var driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
            driver.Manage().Window.Maximize();
        }

        public void AlertAccept()
        {
            var driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void Refresh()
        {
            var driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
            driver.Navigate().Refresh();
        }

        public void SwitchToNextTab(IWebDriver driver, string existingWindowHandle)
        {
            string newtabHandle = string.Empty;
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    newtabHandle = handle;
                    break;
                }
            }

            //switch to new tab 
            driver.SwitchTo().Window(newtabHandle);
        }


        public void CloseOtherTab(IWebDriver driver, string existingWindowHandle)
        {
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            Console.WriteLine(windowHandles.Count);
            foreach (string handle in windowHandles)
            {
                if (!handle.Equals(existingWindowHandle))
                {
                    driver.SwitchTo().Window(handle);
                    driver.Close();
                }
            }
        }


        public void SwitchBackToOriginalTab(IWebDriver driver, string existingWindowHandle)
        {
            // CloseOtherTab(driver, existingWindowHandle);
            driver.SwitchTo().Window(existingWindowHandle);
        }

    }
}
