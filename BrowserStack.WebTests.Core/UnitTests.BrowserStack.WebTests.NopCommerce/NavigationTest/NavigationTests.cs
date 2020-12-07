using BrowserStack.WebTests.NopCommerce.Site.Home;
using BrowserStack.WebTests.NopCommerce.TestData.Constants;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.BrowserStack.WebTests.NopCommerce.NavigationTest
{
   public  class NavigationTests : TestFixtureBase
    {
        [Test]
        [Category(" NopCommerce > Navigation")]
        public void NavigateToStoreDemo()
        {
            var Home = this.NopCommerce.GetCurrentPage<HomePage>();
            Home.TopMenuList(GenericConstants.PRODUCT).AssertIsVisible();
            Home.TopMenuList(GenericConstants.PRODUCT).Click();
            Home.SubMenuList(GenericConstants.STORE_DEMO).AssertIsVisible ();
            Home.SubMenuList(GenericConstants.STORE_DEMO).Click();
            Home.PageTitle.AssertText("nopCommerce Store Demo");
           
        }
        [Test]
        [Category(" NopCommerce > Navigation")]
        public void NavigateToMarketplace()
        {
            var Home = this.NopCommerce.GetCurrentPage<HomePage>();
            Home.TopMenuList(GenericConstants.DOWNLOADS).AssertIsVisible();
            Home.TopMenuList(GenericConstants.DOWNLOADS).Click();
            Home.SubMenuList(GenericConstants.MARKETPLACE).AssertIsVisible();
            Home.SubMenuList(GenericConstants.MARKETPLACE).Click();
            Home.PageTitle.AssertText(GenericConstants.MARKETPLACE);

        }
        [Test]
        [Category(" NopCommerce > Navigation")]
        public void NavigateToDocumentation()
        {
            var Home = this.NopCommerce.GetCurrentPage<HomePage>();
            Home.TopMenuList(GenericConstants.SUPPORT_SERVICES).AssertIsVisible();
            Home.TopMenuList(GenericConstants.SUPPORT_SERVICES).Click();
            Home.SubMenuList(GenericConstants.DOCUMENTATION).AssertIsVisible();
            Home.SubMenuList(GenericConstants.DOCUMENTATION).Click();
            Home.PageTitle.AssertText("nopCommerce Documentation");

        }
    }
}
