using Autofac;
using BrowserStack.WebTests.Core.PageObjects;

namespace BrowserStack.WebTests.NopCommerce.Common
{
    public class CommonPages : IPageSection
    {
        private readonly IComponentContext _context;

        public CommonPages(IComponentContext context)
        {
            _context = context;
        }

       
        public Login PMLogin => _context.Resolve<Login>();
        public Logout Logout => _context.Resolve<Logout>();
       

    }
}
