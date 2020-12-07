using OpenQA.Selenium;
using System;

namespace BrowserStack.WebTests.Core.Exceptions
{
    public class PageNotLoadedException : Exception
    {
        public PageNotLoadedException(By selector, string currentUrl, string expectedRoute) :
            base($"Did not find expected element {selector?.ToString()} in GoToPage with current url as {currentUrl} with expected route {expectedRoute}")
        {

        }
    }
}
