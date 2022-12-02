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

namespace SeleniumTasks
{
    internal class Task5
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void FlipKart()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            driver.Manage().Window.Maximize();
            //Actions ac = new Actions(driver);
            //ac.SendKeys(Keys.Escape).Build().Perform();
            driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2doB4z']")).Click();
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Login')]")));

            //driver.FindElement(By.XPath("//div[contains(text(),'Grocery')]")).Click();
            //Thread.Sleep(5000);
            //string title = driver.Title;
            //Assert.IsTrue(driver.Title.Contains("Flipkart Grocery Store"),title);
            //driver.Navigate().Back();
            int i = 0;
            IList<IWebElement> webElements = driver.FindElements(By.XPath("//div[@class='eFQ30H']"));
            foreach (var item in webElements)
            {
                Assert.IsTrue(item.Displayed);
                Console.WriteLine(item.Text);
                i++;
            }

            bool mobiles=driver.FindElement(By.XPath("//div[contains(text(),'Mobiles')]")).Displayed;
            Assert.IsTrue(mobiles);

            bool fashion = driver.FindElement(By.XPath("//div[contains(text(),'Fashion')]")).Displayed;
            Assert.IsTrue(fashion);

            bool Electronics = driver.FindElement(By.XPath("//div[contains(text(),'Electronics')]")).Displayed;
            Assert.IsTrue(Electronics);

            bool Home = driver.FindElement(By.XPath("//div[contains(text(),'Home')]")).Displayed;
            Assert.IsTrue(Home);


            bool Appliances = driver.FindElement(By.XPath("//div[contains(text(),'Appliances')]")).Displayed;
            Assert.IsTrue(Appliances);

            bool Travel = driver.FindElement(By.XPath("//div[contains(text(),'Travel')]")).Displayed;
            Assert.IsTrue(Travel);


            bool Top_Offers = driver.FindElement(By.XPath("//div[contains(text(),'Top Offers')]")).Displayed;
            Assert.IsTrue(Top_Offers);


            bool Beaut_Toys = driver.FindElement(By.XPath("//div[contains(text(),'Beauty, Toys & More')]")).Displayed;
            Assert.IsTrue(Beaut_Toys);


            bool Tw0Wheelers = driver.FindElement(By.XPath("//div[contains(text(),'2-Wheelers')]")).Displayed;
            Assert.IsTrue(Tw0Wheelers);

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



           IWebElement before_click= driver.FindElement(By.XPath("//body/div[@id='container']/div[1]/div[3]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/a[1]/div[2]/div[2]/div[1]/div[1]/div[1]"));
            //(//div[@class='MIXNux'])[2]/following::div[1]/div[2]/div/div/div)[1]
            string parent = driver.CurrentWindowHandle;
            string befor_price = before_click.Text;
            before_click.Click();
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);
            string after_price = driver.FindElement(By.XPath("//body/div[@id='container']/div[1]/div[3]/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]")).Text;
            Console.WriteLine(befor_price);
            Console.WriteLine(after_price);

            Assert.IsTrue(befor_price == after_price);
            driver.Close();
            driver.SwitchTo().Window(parent);











        }
        [TearDown]
        public void Close()
        {
           // driver.Close();
        }
    }
}
