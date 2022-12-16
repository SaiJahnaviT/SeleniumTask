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

        public string GetText(By path)
        {
            return driver.FindElement(path).Text;
        }
        
        public bool URLContains(string s)
        {
            return driver.Url.Contains(s);
        }

        public void JavaScriptScroll(By path)
        {
            IWebElement ele = driver.FindElement(path);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        public bool IsDisplayed(By path)
        {
            return driver.FindElement(path).Displayed;

        }

        public string GetPrice(string[] ItemValues)
        {
            return ItemValues[2];
        }

        public string GetAddToCart(string[] ItemValues)
        {
            return ((ItemValues[3] + " " + ItemValues[0]).Replace(" ", "-"));

        }

        public string[] GetTrimed(string[] texts)
        {
            for (int k = 0; k < texts.Length; k++)
            {
                texts[k] = texts[k].Trim().ToLower();
            }
            return texts;
        }

        public string[] GetAllText(IWebElement element)
        {

            return element.Text.Split("\n");
        }

        public string GetItemName(string[] texts)
        {
            return texts[0].Trim();
        }

        public string[] GetItemValues(string[] texts)
        {
            string[] TrimedTexts = GetTrimed(texts);
            string[] ItemValues = { GetPrice(TrimedTexts), GetAddToCart(TrimedTexts) };
            return ItemValues;
        }

        public By GetInputById(string path)
        {
            return By.Id(path);
        }

        public By GetInputByDivClass(string value)
        {
            return By.XPath($"//div[@class='{value}']");
        }
    }
}
