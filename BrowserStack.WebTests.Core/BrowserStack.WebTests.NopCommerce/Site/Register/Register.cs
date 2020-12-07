using BrowserStack.WebTests.Core.WebElements;
using BrowserStack.WebTests.Core.WebElements.FormElements;
using BrowserStack.WebTests.NopCommerce.Site.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserStack.WebTests.NopCommerce.Site.Register
{
   
    public class Register : CommonUtility
    {
        public Register() : base()
        {
           
            this.FirstName = new ThInput("#FirstName");
            this.LastName = new ThInput("#LastName");
            this.Email = new ThInput("#Email");
            this.ConfirmEmail = new ThInput("#ConfirmEmail");
            this.Username = new ThInput("#Username");
            this.Password = new ThInput("#Password");
            this.ConfirmPassword = new ThInput("#ConfirmPassword");
            this.RegisterButton = new ThButton(".register-button");
            this.CheckAvailability= new ThButton(".check-availability-button");
            this.Details_CompanyIndustryId = new ThSelect(".Details_CompanyIndustryId");
            this.Details_CompanyRoleId = new ThSelect(".Details_CompanyRoleId");
            this.Details_CompanySizeId = new ThSelect(".Details_CompanySizeId");

            //Details_ExtensionsDevelopmentPeriodId
            //is-nop-commerce-extensions-true
        }
        public override string Route => "/register?returnUrl=%2Fen%2Fdemo";
        public override bool IsRouteComparisonAllowed => false;
        public override bool IsAngular => false;

        public ThButton RegisterButton { get; set; }
        public ThInput FirstName { get; set; }
        public ThInput LastName { get; set; }
        public ThInput Email { get; set; }
        public ThInput ConfirmEmail { get; set; }
        public ThInput Username { get; set; }
        public ThInput Password { get; set; }
        public ThInput ConfirmPassword { get; set; }
        public ThButton CheckAvailability { get; set; }
        public ThSelect Details_CompanyIndustryId { get; set; }
        public ThSelect Details_CompanyRoleId { get; set; }
        public ThSelect Details_CompanySizeId { get; set; }
        public ThSelect Details_ExtensionsDevelopmentPeriodId { get; set; }
        public ThRadio Nop_Commerce_Extensions { get; set; }

    }
}
