using OpenQA.Selenium;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using OrangeHRMCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.Navigation
{
    public class Navigate : BasePage
    {
        string CataLogItemsList = "oxd-main-menu-item-wrapper";

        Dictionary<string, IWebElement> CatalogItems =new Dictionary<string, IWebElement>();

        public void AddCatalogItems()
        {

            IList<IWebElement> Catalog = driver.FindElements(By.XPath($"//li[@class='{CataLogItemsList}']"));

            foreach(IWebElement item in Catalog )
            {
                CatalogItems[item.Text] = item;
            }
        }

        public void NavigatetoPage(string name)
        {
            if (CatalogItems.ContainsKey(name))
            {
                CatalogItems[name].Click();
            }
            else
            {
                throw new Exception("Page not Found");
            }
            
        }

    }
}
