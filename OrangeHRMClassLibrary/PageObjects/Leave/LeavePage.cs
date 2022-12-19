using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using OrangeHRMCommonLibrary.Utility;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Leave
{
    public class LeavePage : BasePage
    {

        string FromDate;
        string ToDate;

        public bool IsNavigatedToLeave()
        {
            wait.waitElementIsVisible(By.TagName("h5"));
            return utility.utility.IsDisplayed(By.TagName("h5"));
        }

        public void GetDates()
        {
            wait.waitElementIsVisible(utility.utility.GetDatesByLabelName("From"));

            utility.utility.UntilLoad();

            utility.JavaScriptScroll(utility.GetInputByDivClass(Table.EntryTable));

            String Date = utility.utility.GetFirstInputFromTable(Table.EntryTable);

            string[] Dates = utility.utility.GetDates(Date);

            if (Dates.Length > 1)
            {
                FromDate = Dates[0];
                ToDate = Dates[1];
                step.Log(Status.Info, "From Date " + FromDate);
                step.Log(Status.Info, "To Date" + ToDate);
            }
            else
            {
                FromDate = Dates[0];
                step.Log(Status.Info, "From Date " + FromDate);
            }

        }

        public void EnterDates()
        {
            Actions actions = new Actions(driver);

            IWebElement Fromdate = utility.FindElement((utility.utility.GetDatesByLabelName("From")));
           
            actions.Click(Fromdate).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();

            utility.utility.Sendkeys(utility.utility.GetDatesByLabelName("From"),FromDate);

            wait.waitElementIsVisible(utility.GetButton(Buttons.Submit));

            step.Log(Status.Info, "Dates Entered");
        }
         
        public bool IsRecordsDisplayed()
        {

            utility.UntilLoad();
            string result = utility.FindElement(By.XPath(Logos.RecordsDetails)).Text;
            Console.WriteLine(result);
            step.Log(Status.Info, result);
            return utility.IsDisplayed(By.XPath(Logos.RecordsDetails));


        }
    }
}
