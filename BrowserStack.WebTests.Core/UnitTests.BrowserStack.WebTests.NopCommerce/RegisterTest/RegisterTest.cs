using BrowserStack.WebTests.NopCommerce.Site.Home;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BrowserStack.WebTests.NopCommerce.Site.Register;
namespace UnitTests.BrowserStack.WebTests.NopCommerce.RegisterTest
{

    public class RegisterTest : TestFixtureBase
    {

        [Test]
        [Category(" NopCommerce > Register")]
        public void _135603()
        {
            var Home = this.NopCommerce.GetCurrentPage<HomePage>();
            Home.userlink.Click();
            Home.RegisterLink.Click();
            var Register = this.NopCommerce.GetCurrentPage<Register>();
            Register.FirstName.AssertIsVisible();
            Register.FirstName.Value = "rtrtgf";
            Register.LastName.Value = "rtrtgf";
            Register.Email.Value = "rtrtgf";
            Register.ConfirmEmail.Value = "rtrtgf";
            Register.Username.Value = "rtrtgf";
            Register.Password.Value = "User@123";
            Register.ConfirmPassword.Value = "User@123";
            Register.Details_CompanyIndustryId.Value = "Develops nopCommerce extensions";
            Register.Details_CompanyRoleId.Value = "Technical developer";
            Register.Details_ExtensionsDevelopmentPeriodId.Value = "Over 6 years";
            Register.Nop_Commerce_Extensions.Checked = true;
            Register.Details_CompanySizeId.Value = "More than 15";

        }
    }

}
