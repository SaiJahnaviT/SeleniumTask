using OpenQA.Selenium;
using SauceDemoCommonLibrary.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SauceDemoCommonLibrary.Utility
{
    public class utility : BasePage
    {
        public void NaviagateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public IList<IWebElement> GetList(By path)
        {
            IList<IWebElement> inventory_items =  driver.FindElements(path);
            return inventory_items;
        }

        public void Sendkeys(By path, string key)
        {
            try
            {
                driver.FindElement(path).SendKeys(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Check Path");
            }
           
        }

        public void ClickElement(By path)
        {
            driver.FindElement(path).Click();
        }

        public string gettext(By path)
        {
            return driver.FindElement(path).Text;
        }

        
        public bool URLContains(string s)
        {
            return driver.Url.Contains(s);
        }

        public void js_scroll(By path)
        {
            IWebElement ele = driver.FindElement(path);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        public bool IsDisplayed(By path)
        {
            return driver.FindElement(path).Displayed;

        }
       
    }
}
