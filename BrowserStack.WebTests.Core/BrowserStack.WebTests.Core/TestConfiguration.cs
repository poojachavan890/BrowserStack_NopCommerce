using System.Collections.Generic;

namespace BrowserStack.WebTests.Core
{
    public class TestConfiguration : ITestConfiguration
    {
        public string BaseQAUrl { get; set; }
        public Dictionary<string, string> BaseQAUrls { get; set; }
        public string RemoteSeleniumServerUrl { get; set; }
        public bool AcceptInsecureCertificates { get; set; }
        public string Browser { get; set; }
        public string TestDataFile { get; set; }
        /// <summary>
        /// How long to wait for a page to load.  You can override specific pages in their page model
        /// </summary>
        public int? PageLoadTimeout { get; set; }

        public string Environment { get; set; }
    }
}
