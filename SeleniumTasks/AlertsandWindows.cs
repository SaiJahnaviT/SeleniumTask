using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTasks.Driver;

namespace SeleniumTasks
{
    internal class AlertsandWindows : Driverinit
    {
        [Test]
        #region Alerts
        public void Alerts()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            driver.FindElement(By.XPath("//button[@id='alertButton']")).Click();
            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
            IWebElement sp = driver.FindElement(By.XPath("//span[contains(text(),'On button click, prompt box will appear')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sp);
            driver.FindElement(By.XPath("//button[@id='timerAlertButton']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.AlertIsPresent());
            IAlert timeAlert = driver.SwitchTo().Alert();
            timeAlert.Accept();
            driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
            IAlert confirmAlert = driver.SwitchTo().Alert();
            confirmAlert.Accept();
            driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
            IAlert confirmmAlert = driver.SwitchTo().Alert();
            confirmmAlert.Dismiss();
            driver.FindElement(By.XPath("//button[@id='promtButton']")).Click();
            IAlert promptAlert = driver.SwitchTo().Alert();
            promptAlert.SendKeys("jahnavi");
            promptAlert.Accept();

        }
        #endregion


        [Test]
        #region WindowHandles
        public void WindowHandlesss()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();
            string parentHandle = driver.CurrentWindowHandle;
            Console.WriteLine("parent handle "+parentHandle);
            driver.FindElement(By.XPath("//button[contains(text(),'New Tab')]")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("number of windows opened "+driver.WindowHandles.Count);
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);
            Console.WriteLine("Current handle "+driver.CurrentWindowHandle);
            driver.Close();
            driver.SwitchTo().Window(parentHandle);
            Console.WriteLine("Current handle " + driver.CurrentWindowHandle);
            Console.WriteLine("\t ----------NEW WINDOW-------------\t");

            driver.FindElement(By.XPath("//button[@id='windowButton']")).Click();
            Console.WriteLine("number of windows opened " + driver.WindowHandles.Count);
            ReadOnlyCollection<string> windowHandles2 = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles2[1]);
            Console.WriteLine("Current handle " + driver.CurrentWindowHandle);
            driver.Close();
            driver.SwitchTo().Window(parentHandle);

            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            driver.FindElement(By.XPath("//button[@id='showSmallModal']")).Click();
            Console.WriteLine("------------------Dialog------------------");
            ReadOnlyCollection<string> windowHandles_dialogs = driver.WindowHandles;
            foreach(var item in windowHandles_dialogs)
            {
                Console.WriteLine(item);
            }
           // driver.SwitchTo().Window(windowHandles_dialogs[1]);
            driver.FindElement(By.XPath("//button[@id='closeSmallModal']")).Click();
            driver.FindElement(By.XPath("//button[@id='showLargeModal']")).Click();
            driver.FindElement(By.XPath("//button[@id='closeLargeModal']")).Click();


            
        }
        #endregion
    }
}
