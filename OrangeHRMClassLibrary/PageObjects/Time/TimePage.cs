using OpenQA.Selenium;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using OrangeHRMCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Time
{
    public class TimePage : BasePage
    {
        public bool IsNavigatedToTime()
        {
            wait.waitElementIsVisible(By.XPath(Logos.SelectEmployee));
            return utility.IsDisplayed(By.XPath(Logos.SelectEmployee));
        }

        public bool IsTableDisplayed()
        {
            wait.waitElementIsVisible(utility.GetInputByDivClass(Table.EntryTable));
            return utility.IsDisplayed(utility.GetInputByDivClass(Table.EntryTable));
        }
    }
}
