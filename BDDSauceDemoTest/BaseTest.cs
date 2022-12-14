using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using SauceDemoLibrary.Pages;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SauceDemoCommonLibrary.Base;

namespace BDDSauceDemoTest
{
    public class BaseTest : BasePage
    {
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //test = extentReports.CreateTest("Login Test").Info("test started");


        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentReports = new ExtentReports();
            string currentDirectory = Environment.CurrentDirectory;
            string project = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string filePath = project + @"\Reports\Report.html";
            var htmlReporter = new ExtentHtmlReporter(filePath);
            extentReports.AttachReporter(htmlReporter);
            test = extentReports.CreateTest("Login Test").Info("test started");
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentReports.Flush();
        }
        [TearDown] public void TearDown() 
        { 
            driver.Close();
        }   


        
    }
}