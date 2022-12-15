using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SauceDemoCommonLibrary.Base;
using SauceDemoLibrary.Pages; 

namespace BDDSauceDemoTest
{
    public class BaseTest : BasePage
    {
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            


        }
        [TearDown] public void TearDown() 
        { 
            driver.Close();
        }   


        
    }
}