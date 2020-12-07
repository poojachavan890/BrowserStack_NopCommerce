using System;
using BrowserStack.WebTests.Core.PageObjects;
using BrowserStack.WebTests.Core.WebElements;

namespace BrowserStack.WebTests.NopCommerce.Common
{
    public class Logout : BasePage
    {
        public Logout() : base()
        {
            this.ProfileIcon = new ThButton(null, "//div[@class='icon avatar-icon']");
            this.LogOut = new ThLink(null, "//a[text()='Logout']");
            this.ProfileIconSetUpPage = new ThLink(null, "//a[@id='ProfileLink']");
            this.LogoutlinkSetUpPage = new ThButton(null, "//ul[@class='AccountSubMenu']//a[text()='Logout']");
            this.SSProfileIcon = new ThButton(null, "//div[@id='profile-menu']");
            this.SSLogoutlink = new ThButton("//div[@id='profile-menu']//a[text()='Logout']");
            this.LogoutConfirmationMessage = new ThTextElement(null, "//p[text()='Are you sure you want to sign out?']");
            this.LogoutYes = new ThButton(null, "//input[@Value='Yes']");
        }

        public override string Route => "//logout.aspx";
        public override bool IsAngular => false;

        public ThButton ProfileIcon { get; set; }
        public ThLink LogOut { get; set; }
        public ThTextElement LogoutConfirmationMessage { get; set; }
        public ThButton SSProfileIcon { get; set; }
        public ThButton LogoutYes { get; set; }

        public ThButton SSLogoutlink { get; set; }

        public ThLink ProfileIconSetUpPage { get; set; }

        public ThButton LogoutlinkSetUpPage { get; set; }

        public override string BaseUrl
        {
            get
            {
                string baseUrl = "";
                if (this.Configuration.BaseQAUrls != null && this.Configuration.BaseQAUrls.ContainsKey("SecretServer"))
                {
                    baseUrl = this.Configuration.BaseQAUrls["SecretServer"];
                }

                return baseUrl;
            }
        }
        public void logout()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            this.ProfileIcon.WaitForElementToVisible();
            this.ProfileIcon.Click();
            this.LogOut.Click();

        }
        public void Cloudlogout()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            this.ProfileIcon.WaitForElementToVisible();
            this.ProfileIcon.Click();
            this.LogOut.Click();
            if (LogoutConfirmationMessage.ElementExists())
                LogoutYes.Click();
        }
        public void SSlogout()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            this.SSProfileIcon.WaitForElementToVisible();
            this.SSProfileIcon.Click();
            this.SSLogoutlink.WaitForElementToVisible();
            this.SSLogoutlink.Click();

        }
        public void logoutFromSetUPPage()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            this.ProfileIconSetUpPage.WaitForElementToVisible();
            this.ProfileIconSetUpPage.Click();
            this.LogoutlinkSetUpPage.WaitForElementToVisible();
            this.LogoutlinkSetUpPage.Click();

        }
    }
}
