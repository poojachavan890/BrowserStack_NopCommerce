using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BrowserStack.WebTests.Core;


namespace BrowserStack.WebTests.NopCommerce.TestData
{
    public class TestDataService
    {
        private readonly ITestConfiguration _config;
        public Models.TestData Data { get; set; }

        public TestDataService(
            ITestConfiguration config
        )
        {
            _config = config;
        }

        public static Models.TestData GetData(ITestConfiguration config)
        {
            string jsonText = null;
            var assembly = Assembly.GetAssembly(typeof(TestDataService));
            var resourceName = "BrowserStack.WebTests.NopCommerce.TestData.Data." + config.TestDataFile;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }
            }

            var data = JsonConvert.DeserializeObject<Models.TestData>(jsonText);
           
            return data;
        }

        public void LoadData()
        {
            Data = GetData(_config);
        }
    }
}