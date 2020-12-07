using BrowserStack.WebTests.Core.PageObjects;
using BrowserStack.WebTests.Core.WebElements;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrowserStack.WebTests.NopCommerce.Site.Utils
{

    public abstract class CommonUtility : BasePage
    {
        protected CommonUtility() : base()
        {

        }
        readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ThMenu AdminMenu { get; set; }
        public abstract override string Route { get; }
        public override bool IsAngular => true;

        public void VerifyDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
        }
        public void TakeScreenShot(string path, string method)
        {

            string filepath = path + "\\" + DateTime.Now.ToString("MM_dd_yyyy") + "\\" + method + "\\";
            VerifyDir(filepath);
            String fileName = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_tt") + ".png";
            try
            {
                Screenshot file = ((ITakesScreenshot)Driver).GetScreenshot();
                file.SaveAsFile(filepath + fileName, ScreenshotImageFormat.Png);
            }
            catch (IOException e)
            {

                Console.WriteLine($"Screenshot not captured....{e.Message}");
            }

        }
    }
   

}
