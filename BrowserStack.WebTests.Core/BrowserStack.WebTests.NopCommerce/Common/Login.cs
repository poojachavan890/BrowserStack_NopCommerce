using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using BrowserStack.WebTests.Core.PageObjects;
using BrowserStack.WebTests.Core.WebElements;
using BrowserStack.WebTests.Core.WebElements.FormElements;


namespace BrowserStack.WebTests.NopCommerce.Common
{
    public class Login : BasePage
    {
        public Login() : base()
        {
            this.Username = new ThInput("#LoginUserControl1_UserNameTextBox");
            this.Password = new ThInput("#LoginUserControl1_PasswordTextBox");
            this.LoginButton = new ThButton("#LoginUserControl1_LoginButton");
            this.Home = new ThLabel(null, "//span[text()='Home']");
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Path.Combine(assemblyPath, "RoleUser.json");
            this.DefaultSecretServer = new ThLink(null, "//ul[@class='auth-list']/li/a[contains(text(),'Default Secret Server')]");
            this.NopCommerce = new ThLink(null, "//div[@class='column column-12']//a[contains(text(),'Privilege Manager')]");
            this.Next = new ThButton(null, "//button[text()='Next']");
            this.Email = new ThInput(null, "//input[@placeholder='Enter Email Address']");
            this.CloudPassword = new ThInput(null, "//input[@id='Password']");
            this.BrowserStackOne = new ThLink(null, "(//ul[@class='auth-list']/li/a[contains(text(),'BrowserStack One')])[1]");
            this.StandardUsername = new ThInput(null, "//input[@id='userName']");
            this.StandardPassword = new ThInput(null, "//input[@id='password']");
            this.StandardUserLogin = new ThButton(null, "//button[@id='login-btn']");
            this.ErrorClass = new ThTextElement(null, "//div[@class='form-group alert-danger']");
            this.InvalidPasswordError = new ThTextElement(null, "//span[contains(text(),'The given password is invalid')]");
            this.InvalidUserNameError = new ThTextElement(null, "//span[contains(text(),'Unable to find the ID of the user with name')]");
            this.InvalidUserNamePasswordError = new ThTextElement(null, "//span[contains(text(),'Unable to login. Verify that the username and password are correct.')]");
            this.ErrorMessage = new ThTextElement(null, "//span[@class='control-label']");
            this.StandardUserLogoHeader = new ThTextElement(null, "//h4[text()='Privilege Manager']");
            this.StandardUserLoginlabel = new ThTextElement(null, "//span[text()='Log in to your account']");
            this.StandardLoginButton = new ThButton(null, "//button[@id='login-btn']");
            this.DefaultNTLMAuthentication = new ThButton(null, "//ul[@class='auth-list']/li/a[contains(text(),'Default NTLM Authentication')]");
            this.AzureAD = new ThButton(null, "//p[text()='qa.BrowserStack.com']//parent::a");
            AzureADUserName = new ThInput(null, "//input[@type='email']");
            MicrosoftLogo = new ThTextElement(null, "//img[@alt='Microsoft']");
            this.LOGIN = new ThButton(null, "//ul[@class='main_navigation']//a[text()='Login']|//a[contains(@href,'/TMS/Account/SignIn')]");
            this.LoginMessage = new ThTextElement(null, "//*[@id='loginMessage']");
            this.ButtonOrLink = new ThLink(null, "//button | //a");
            this.PleaseLoginAgainMessage = new ThTextElement(null, "//p[text()='You have logged in at another location, please login again.']");
            this.LoginAgainLink = new ThLink("#LoginPageLink");
            this.Yes = new ThLink(null, "//input[@name = 'Confirm']");
            this.InvalidLoginAttempt = new ThTextElement(null, "//li[text()='Invalid Login Attempt']");
            this.MoreInformation = new ThLink(null, "//span[@id='moreInfoContainer']//a[contains(text(),'More information')]");
            this.Overridelink = new ThLink(null, "//a[@id='overridelink']");
            this.AzureADLoginNext = new ThButton(null, "//input[@value='Next']");
            this.AzureADPassword = new ThInput(null, "//input[@name='passwd']");
            this.AzureADSignIn = new ThButton(null, "//input[@value='Sign in']");
            this.AzureADStaySignInMessage = new ThTextElement(null, " //div[contains(text(),'Stay signed in?')]");
            this.AzureADStaySignInNoButton = new ThButton(null, "//input[@value='No']");
            this.UseAnotherAccount = new ThButton(null, "//div[@id='otherTileText']");               
            this.UserNameTextBox = new ThInput(null, "//input[@id='UserNameTextBox']");
            this.PasswordTextBox = new ThInput(null, "//input[@id='PasswordTextBox']");
            this.LoginButtonn = new ThButton(null, "//button[@id='LoginButton']");
        }
        public ThInput Username { get; set; }
        public ThInput UserNameTextBox { get; set; }
        public ThInput PasswordTextBox { get; set; }
        public ThButton LoginButtonn { get; set; }
        public ThInput StandardUsername { get; set; }
        public ThInput StandardPassword { get; set; }
        public ThTextElement StandardUserLogoHeader { get; set; }
        public ThTextElement PleaseLoginAgainMessage { get; set; }
        public ThLink LoginAgainLink { get; set; }
        public ThTextElement StandardUserLoginlabel { get; set; }
        public ThInput Password { get; set; }
        public ThButton LoginButton { get; set; }
        public ThButton DefaultNTLMAuthentication { get; set; }
        public ThTextElement MicrosoftLogo { get; set; }
        public ThButton AzureAD { get; set; }
        public ThInput AzureADUserName { get; set; }
        public ThButton AzureADLoginNext { get; set; }
        public ThInput AzureADPassword { get; set; }
        public ThButton AzureADSignIn { get; set; }
        public ThTextElement AzureADStaySignInMessage { get; set; }
        public ThButton AzureADStaySignInNoButton { get; set; }
        public ThButton StandardLoginButton { get; set; }
        public ThButton StandardUserLogin { get; set; }
        public ThLink DefaultSecretServer { get; set; }
        public ThLink BrowserStackOne { get; set; }
        public ThLink NopCommerce { get; set; }
        public ThTextElement ErrorClass { get; set; }
        public ThTextElement ErrorMessage { get; set; }
        public ThTextElement InvalidUserNameError { get; set; }
        public ThTextElement InvalidUserNamePasswordError { get; set; }
        public ThTextElement InvalidPasswordError { get; set; }
        public ThLabel Home { get; set; }
        public override string Route => "";
        public override bool IsRouteComparisonAllowed => false;
        public override bool IsAngular => false;
        public ThButton Next { get; set; }
        public ThInput Email { get; set; }
        public ThInput CloudPassword { get; set; }
        public ThButton LOGIN { get; set; }
        public ThLink ButtonOrLink { get; set; }
        public ThLink Yes { get; set; }
        public ThTextElement LoginMessage { get; set; }
        public ThTextElement InvalidLoginAttempt { get; set; }
        public ThLink MoreInformation { get; set; }
        public ThLink Overridelink { get; set; }
        public ThButton UseAnotherAccount { get; set; }
        public void LoginAsStandardUser(string UserName, string Password)
        {
            StandardUsername.WaitForElementToVisible(60);
            StandardUsername.Value = UserName;
            StandardPassword.Value = Password;
            StandardUserLogin.Click();
        }

       
        public void LoginToCloud()
        {
            if (BrowserStackOne.ElementExists())
            {
                BrowserStackOne.Click();
            }
            this.Email.Value = TestContext.Parameters.Get("username");
            Next.Click();
            this.CloudPassword.Value = TestContext.Parameters.Get("password");
            Next.Click();

            if (NopCommerce.ElementExists())
                NopCommerce.Click();
        }

       

        public void LoginDefaultSSUser()
        {
            DefaultSecretServer.Click();
            this.Username.Value = "pmqasvc";
            this.Password.Value = "fPT&!1oTV*y";
            LoginButton.Click();

        }

       
        public void NavigateToTMS()
        {
            this.Driver.Navigate().GoToUrl(this.Configuration.BaseQAUrls["TMSURL"]);
            long loadtime = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.loadEventEnd - performance.timing.navigationStart;");
            Console.WriteLine("Time to load page is: " + loadtime + " miliseconds");
            long NavigationStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.navigationStart");
            long ResponseStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.responseStart");
            long DomComplete = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.domComplete");
            long backendPerformance_calc = ResponseStart - NavigationStart;
            long frontendPerformance_calc = DomComplete - ResponseStart;
            Console.WriteLine("Back End: " + backendPerformance_calc);
            Console.WriteLine("Front End:: " + frontendPerformance_calc);
        }

        public void NavigateToCloudTMS()
        {
            this.Driver.Navigate().GoToUrl(this.Configuration.BaseQAUrls["TMSURL"] + "/");
            long loadtime = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.loadEventEnd - performance.timing.navigationStart;");
            Console.WriteLine("Time to load page is: " + loadtime + " miliseconds");
            long NavigationStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.navigationStart");
            long ResponseStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.responseStart");
            long DomComplete = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.domComplete");
            long backendPerformance_calc = ResponseStart - NavigationStart;
            long frontendPerformance_calc = DomComplete - ResponseStart;
            Console.WriteLine("Back End: " + backendPerformance_calc);
            Console.WriteLine("Front End:: " + frontendPerformance_calc);
        }
        public void VerifyStandardUserLoginPagePresent()
        {
            StandardUserLogoHeader.AssertIsVisible();
            StandardUserLoginlabel.AssertIsVisible();
            StandardUsername.AssertIsVisible();
            StandardPassword.AssertIsVisible();
            StandardUserLogin.AssertIsVisible();
            DefaultSecretServer.AssertIsVisible();
        }

        public void VerifyMultpleCloudLoginOptions()
        {
            StandardUsername.AssertIsVisible();
            StandardPassword.AssertIsVisible();
            StandardUserLogin.AssertIsVisible();
            AzureAD.AssertIsVisible();
        }

        public void LoginAsNTLM()

        {
            DefaultNTLMAuthentication.Click();
            string baseUrl = "";
            string username = "pmqasvc";
            string password = "fPT&!1oTV*y";
            if (this.Configuration.BaseQAUrls != null && this.Configuration.BaseQAUrls.ContainsKey("SetupURL"))
            {
                baseUrl = this.Configuration.BaseQAUrls["SetupURL"];
                baseUrl = baseUrl.Replace("{username}:{password}", $"{username}:{password}");
            }
            this.Driver.Navigate().GoToUrl(baseUrl);
            long loadtime = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.loadEventEnd - performance.timing.navigationStart;");
            Console.WriteLine("Time to load page is: " + loadtime + " miliseconds");
            long NavigationStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.navigationStart");
            long ResponseStart = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.responseStart");
            long DomComplete = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return performance.timing.domComplete");
            long backendPerformance_calc = ResponseStart - NavigationStart;
            long frontendPerformance_calc = DomComplete - ResponseStart;
            Console.WriteLine("Back End: " + backendPerformance_calc);
            Console.WriteLine("Front End:: " + frontendPerformance_calc);
        }
        public void LoginToIE()
        {
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            if (Driver.Url.Contains("https"))
            {
                IWebElement MoreInfo = Driver.FindElement(By.XPath("//span[@id='moreInfoContainer']//a[contains(text(),'More information')]"));
                executor.ExecuteScript("arguments[0].click();", MoreInfo);
                IWebElement GoToTMS = Driver.FindElement(By.XPath("//a[@id='overridelink']"));
                executor.ExecuteScript("arguments[0].click();", GoToTMS);
            }
            DefaultSecretServer.WaitForElementToVisible(60);
            DefaultSecretServer.AssertIsVisible();
            IWebElement DefaultSS = Driver.FindElement(By.XPath("//ul[@class='auth-list']/li/a[contains(text(),'Default Secret Server')]"));
            executor.ExecuteScript("arguments[0].click();", DefaultSS);
            DefaultSecretServer.AssertIsNotVisible();
            this.Username.Value = TestContext.Parameters.Get("username");
            this.Password.Value = TestContext.Parameters.Get("password");
            IWebElement login = Driver.FindElement(By.XPath("//button[@id='LoginUserControl1_LoginButton']"));
            executor.ExecuteScript("arguments[0].click();", login);
            Thread.Sleep(1000);
            if (NopCommerce.ElementExists())
                NopCommerce.Click();
        }

        
    }
}
