using System.Collections.Generic;

namespace BrowserStack.WebTests.Core
{
    public interface ITestConfiguration
    {
        string BaseQAUrl { get; set; }
        Dictionary<string, string> BaseQAUrls { get; set; }
        string RemoteSeleniumServerUrl { get; set; }
        bool AcceptInsecureCertificates { get; set; }
        string Browser { get; set; }
        string TestDataFile { get; set; }
        int? PageLoadTimeout { get; set; }
        string Environment { get; set; }
    }
}
