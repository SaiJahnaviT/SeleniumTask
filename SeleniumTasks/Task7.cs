using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using SeleniumTasks.Driver;

namespace SeleniumTasks
{
    internal class Task7 : Driverinit 
    {
        

        [Test]
        public void Epam()
        {


            driver.Navigate().GoToUrl("https://www.epam.com");
            WebDriverWait w= new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.TitleContains("EPAM"));
            driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']")).Click();
            //  SelectElement f = new SelectElement(driver.FindElement(By.XPath("//ul[@class='frequent-searches__items']")));

            IList<IWebElement> f = driver.FindElements(By.XPath("//ul[@class='frequent-searches__items']//li"));
            string search = f[2].GetAttribute("innerHTML");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", f[2]);
            
           // var search=((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].value", f[2]);
            Console.WriteLine(search);
            driver.FindElement(By.XPath("//button[contains(text(),'Find')]")).Click();
            IList<IWebElement> articles = driver.FindElements(By.XPath("//div[@class='search-results__items']/article"));
            foreach (var a in articles)
            {
                Assert.True(a.Text.Contains(search));
            }


        }
        
    }
}
