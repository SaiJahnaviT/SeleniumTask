using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTasks
{
    internal class Widgets
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void Accordian()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/accordian");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//div[contains(text(),'What is Lorem Ipsum?')]"));

        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
