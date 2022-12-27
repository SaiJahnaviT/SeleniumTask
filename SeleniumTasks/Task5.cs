using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net;
using System.Collections.ObjectModel;
using SeleniumTasks.Driver;

namespace SeleniumTasks
{
    internal class Task5 : Driverinit
    {

        [Test]
        public void FlipKart()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.flipkart.com/");
                driver.Manage().Window.Maximize();
                //Actions ac = new Actions(driver);
                //ac.SendKeys(Keys.Escape).Build().Perform();
                driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2doB4z']")).Click();
                WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                w.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Login')]")));


                int i = 0;
                IList<IWebElement> webElements = driver.FindElements(By.XPath("//div[@class='eFQ30H']"));
                foreach (var item in webElements)
                {
                    Assert.IsTrue(item.Displayed);
                    Console.WriteLine(item.Text);
                    i++;
                }

                IWebElement elect = driver.FindElement(By.XPath("//div[contains(text(),'Electronics')]"));
                Actions action = new Actions(driver);
                action.MoveToElement(elect).Build().Perform();
                driver.FindElement(By.XPath("//a[contains(text(),'Electronics GST Store')]")).Click();
                Thread.Sleep(5000);
                IWebElement tv_app = driver.FindElement(By.XPath("//span[contains(text(),'TVs & Appliances')]"));
                Actions ac_tv_app = new Actions(driver);
                ac_tv_app.MoveToElement(tv_app).Build().Perform();
                driver.FindElement(By.XPath("//a[contains(text(), 'Split ACs')]")).Click();
                Thread.Sleep(6000);



                IWebElement before_click = driver.FindElement(By.XPath("(//div[@data-id='ACNGB7DJUH5MYQBT'])/div/a/div[2]/div[2]/div/div/div"));
                //(//div[@class='MIXNux'])[2]/following::div[1]/div[2]/div/div/div)[1]
                string parent = driver.CurrentWindowHandle;
                string befor_price = before_click.Text;
                before_click.Click();
                ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
                driver.SwitchTo().Window(windowHandles[1]);
                string after_price = driver.FindElement(By.XPath("//div[@class='aMaAEs']/div[4]/div/div/div")).Text;
                Console.WriteLine(befor_price);
                Console.WriteLine(after_price);

                Assert.IsTrue(befor_price == after_price);
                driver.Close();
                driver.SwitchTo().Window(parent);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
