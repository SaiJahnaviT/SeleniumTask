using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTasks.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTasks
{
    internal class Forms : Driverinit
    {
        
        #region Forms
        [Test]
        public void Form()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.FindElement(By.XPath("//input[@id='firstName']")).SendKeys("Jahnavi");
            driver.FindElement(By.XPath("//input[@id='lastName']")).SendKeys("Tulasi");
            driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("jahnavi_tulasi@gmail.com");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            driver.FindElement(By.XPath("//label[contains(text(),'Female')]")).Click();
            driver.FindElement(By.XPath("//input[@id='userNumber']")).SendKeys("999520100065");
            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            SelectElement sy = new SelectElement(driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']")));
            sy.SelectByText("2005");
            SelectElement sm = new SelectElement(driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']")));
            sm.SelectByText("June");
            driver.FindElement(By.XPath("//div[contains(text(),'25')]")).Click();
            IWebElement s= driver.FindElement(By.XPath("//input[@id='subjectsInput']"));
            s.SendKeys("maths");
            Actions a = new Actions(driver);
            a.SendKeys(Keys.Enter).Build().Perform();
            driver.FindElement(By.XPath("//label[contains(text(),'Reading')]")).Click();
            driver.FindElement(By.XPath("//label[contains(text(),'Music')]")).Click();
            driver.FindElement(By.XPath("//input[@id='uploadPicture']")).SendKeys("C:\\Users\\Jahnavi_Tulasi\\Downloads\\download.png");

            driver.Close(); 
        }
        #endregion 
    }
}
