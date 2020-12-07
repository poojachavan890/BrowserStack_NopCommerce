namespace BrowserStack.WebTests.Core.PageObjects
{
    public interface IPage
    {
        string Route { get; }
        bool IsAngular { get; }
        int PageLoadTimeout { get; }
        void BuildElements();
        OpenQA.Selenium.By ElementVisibleAfterLoad { get; set; }
        string BaseUrl { get; }
        bool IsRouteComparisonAllowed { get; set; }
    }
}
