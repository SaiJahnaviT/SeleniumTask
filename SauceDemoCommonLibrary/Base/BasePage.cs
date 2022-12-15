using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoCommonLibrary.Base
{
    public class BasePage
    {
        [ThreadStatic]
        public static IWebDriver driver;
        public static utility utility =new utility();
        public static ExtentReports extentReports = null;
        [ThreadStatic]
        public static ExtentTest test;
        public static WebDriverWait wait;
        
        





    }
}
