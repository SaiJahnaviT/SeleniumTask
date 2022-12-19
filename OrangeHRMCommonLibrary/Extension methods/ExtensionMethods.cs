using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMCommonLibrary.Extension_methods
{
    public static class ExtensionMethods 
    {
        

       public static void waitElementIsVisible(this WebDriverWait w,By path)
       {
            w.Until(ExpectedConditions.ElementIsVisible(path));

       }

        public static void waitforUrl(this WebDriverWait w,string url) 
        { 
            w.Until(ExpectedConditions.UrlContains(url));
        }

        

      





    }
}
