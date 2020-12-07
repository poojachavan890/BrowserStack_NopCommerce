using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using BrowserStack.WebTests.Core.WebElements;
using BrowserStack.WebTests.Core.WebElements.FormElements;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using BrowserStack.WebTests.NopCommerce.Site.Utils;

namespace BrowserStack.WebTests.NopCommerce.Site.Home
{
    public class HomePage : CommonUtility
    {

        public HomePage() : base()
        {
            this.PageTitle = new ThTextElement(null, "//div[@id='ph-title']/h1");
            this.userlink = new ThLink(null, "//a[@class='userlink']");
            this.LogIn = new ThButton(".ico-login");
            this.RegisterLink = new ThLink(".ico-register");
        }

        public override string Route => "";
        public override bool IsRouteComparisonAllowed => false;
        public override bool IsAngular =>  false;
       public ThTextElement PageTitle { get; set; }
        public ThLink userlink { get; set; }
        public ThButton LogIn { get; set; }
        public ThLink RegisterLink { get; set; }

        public ThLink TopMenuList(string Menu)
        {
            var Selector = "//ul[@class='top-menu desktop']/li/span[contains(text(),'" + Menu + "')]";
            return new ThLink(null, Selector);
        }
        public ThLink SubMenuList(string Menu)
        {
            var Selector = "(//ul[@class='sublist']/li/a[contains(text(),'" + Menu + "')])[1]";
            return new ThLink(null, Selector);
        }
        public void IsDashboardVisible(string sReport)
        {
            var Selector = "//pm-dashboard-container[@class='dash-card']/following::a[text()='" + sReport + "']";
            var Report = new ThLink(null, Selector);
            Report.AssertIsVisible();
        }

        public void GoToDemoPage()
        {
            this.Driver.Navigate().GoToUrl(TestContext.Parameters.Get("baseQAUrl"));
        }



    }
}