using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTasks.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static System.Net.Mime.MediaTypeNames;


namespace SeleniumTasks
{
    internal class Elements : Driverinit
    {
        
        [Test]
        public void TextBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            IWebElement full_name = driver.FindElement(By.XPath("//input[@id='userName']"));
            full_name.SendKeys("Jahnavi Tulasi");
            IWebElement Email = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            Email.SendKeys("jahnavi_tulasi@gmail.com");
        }
        [Test]
        public void checkBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            IWebElement b= driver.FindElement(By.XPath("//span[@class='rct-checkbox']"));
            b.Click();
            Console.WriteLine(b.Selected);
            driver.FindElement(By.XPath("//button[@title='Expand all']")).Click();
            IWebElement Desktop= driver.FindElement(By.XPath("//label[@for='tree-node-desktop']/span[1]"));
            Desktop.Click();
            Console.WriteLine(Desktop.Selected);
            

        }
        [Test]
        public void RadioButton()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/radio-button");

            IWebElement yes_button = driver.FindElement(By.XPath("//input[@id='yesRadio']"));
            //WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            // w.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='yesRadio']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", yes_button);
            string y = yes_button.GetAttribute("checked");
            Console.WriteLine(y);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(3000);
        }

       
       [Test]
        public void Buttons()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            driver.Manage().Window.Maximize();
            IWebElement dc=driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            Actions a = new Actions(driver);
            a.MoveToElement(dc).DoubleClick();
            
           //IWebElement ClickMe= driver.FindElement(By.XPath("///html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[3]/button[1]"));
           // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ClickMe);
           // ClickMe.Click();

        }
        
    }
}
