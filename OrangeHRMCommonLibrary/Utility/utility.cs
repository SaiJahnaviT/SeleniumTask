using OpenQA.Selenium;
using OrangeHRMCommonLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMCommonLibrary.Utility
{
    public class utility : BasePage
    {
        public void NaviagateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
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
                //throw new Exception("Check Path");
            }

        }

        public IList<IWebElement> GetList(By path)
        {
            IList<IWebElement> inventory_items = driver.FindElements(path);
            return inventory_items;
        }

        public void ClearElement(By path)
        {
            FindElement(path).Clear();
        }

        public IWebElement FindElement(By path)
        {
            return driver.FindElement(path);
        }

        
        public void ClickElement(By path)
        {
            driver.FindElement(path).Click();
        }

        public string GetText(By path)
        {
            return driver.FindElement(path).Text;
        }


        public bool URLContains(string str)
        {
            return driver.Url.Contains(str);
        }

        public void JavaScriptScroll(By path)
        {
            IWebElement ele = driver.FindElement(path);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        public bool IsDisplayed(By path)
        {
             bool res= driver.FindElement(path).Displayed;
            return res;

        }
        public By GetInputByDivClass(string value)
        {
            return By.XPath($"//div[@class='{value}']");
        }

        public By GetInputByButtonClass(string value)
        {
            return By.XPath($"//button[@class='{value}']");
        }

        public By GetButton(string value)
        {
            return By.XPath($"//button[@type='{value}']");
        }

        public By GetInputByInputName(string name)
        {
            return By.XPath($"//input[@name='{name}']");
        }

        public By GetTextboxByLabelName(string name)
        {
            return By.XPath($"//label[contains(text(),'{name}')]/parent::div/following-sibling::div/input");
        }
        public By GetDropDownByLabelName(string name)
        {
            return By.XPath($"//label[contains(text(),'{name}')]/parent::div/following-sibling::div/div/div/div[1]");
        }

        public By GetDatesByLabelName(string name)
        {
            return By.XPath($"//label[contains(text(),'{name}')]/parent::div/following-sibling::div/div/div/input");
        }

        public void AutoSuggestElement(By element, string text)
        {
            IList<IWebElement> autoSuggest = driver.FindElements(element);
            foreach (IWebElement autoSuggestElement in autoSuggest)
            {
                if (autoSuggestElement.Text.Contains(text))
                {
                    autoSuggestElement.Click();
                    break;
                }
            }

        }

        public void SelectOptionWithIndex(By element)
        {
            
            IList<IWebElement> webElements = driver.FindElements(element);
            for (int autoSuggestions = 0; autoSuggestions < webElements.Count(); autoSuggestions++)
            {
                IWebElement webElement = webElements[autoSuggestions];
                Thread.Sleep(3000);
                webElement.Click();
                break;
            }
        }

        public string GetFirstInputFromTable(string Table)
        {
            Thread.Sleep(2000);
            IWebElement item = FindElement(GetInputByDivClass(Table));
            string[] user = item.Text.Split("\n");
            return user[0].Trim();

        }

        public string[] GetDates(string Dates)
        {
            string[] dates= Dates.Split("to");
            return dates;
        }

        public void ImplicitWait(int time_in_seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time_in_seconds);
        }

        public void UntilLoad()
        {
            Thread.Sleep(5000);
        }

    }
}
