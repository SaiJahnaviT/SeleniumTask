using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTasks
{
    internal class Task4
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void password()
        {

            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            driver.FindElement(By.XPath("//*[@id=\"nav-signin-tooltip\"]/a/span")).Click();
            Assert.IsTrue(driver.Title == "Amazon Sign In");
            IWebElement email = driver.FindElement(By.XPath("//input[@id='ap_email']"));
            email.SendKeys("jahnavis000@gmail.com");
            driver.FindElement(By.XPath("//input[@id='continue']")).Click();
            Console.WriteLine(driver.FindElement(By.XPath("//label[contains(text(),'Password')]")).Displayed);

            IWebElement password = driver.FindElement(By.XPath("//input[@id='ap_password']"));
            password.SendKeys("1234567890");
            string gp = password.GetAttribute("value");
            Console.WriteLine(gp);
            Assert.IsTrue(gp.Length >= 8 && gp.Length <= 12);
            IWebElement signin_button = driver.FindElement(By.XPath("//input[@id='signInSubmit']"));
            //signin_button.Click();
            //WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //w.Until(ExpectedConditions.TitleContains("Amazon.in"));
            //Console.WriteLine(driver.Title);

        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
