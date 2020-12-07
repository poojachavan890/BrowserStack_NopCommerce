using Autofac;
using BrowserStack.WebTests.Core.Site;
using BrowserStack.WebTests.NopCommerce.Common;
using BrowserStack.WebTests.NopCommerce.Site.Home;

namespace BrowserStack.WebTests.NopCommerce.Site
{
    public class NopCommerceSites : TestWebSite
    {
        private readonly IComponentContext _context;

        public NopCommerceSites(IComponentContext context) : base(context)
        {
            _context = context;
        }

        public CommonPages CommonPages => _context.Resolve<CommonPages>();
        public HomePage Home => _context.Resolve<HomePage>();



    }
}
