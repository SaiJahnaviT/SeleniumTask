using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OrangeHRMCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;

namespace OrangeHRMCommonLibrary.Base
{
    public class BasePage
    {
        [ThreadStatic]
        public static IWebDriver driver;
        public static utility utility = new utility();
        public static ExtentReports extentReports = null;
        public static ExtentTest test,scenario,step;
        public static WebDriverWait wait;
        
    }
}
